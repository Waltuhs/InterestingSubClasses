using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features.Components;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Scp330;

namespace InterestingSubClasses.SubClasses
{
    public class SCP999Role : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.SCP999RoleName;
        public override string Description => Plugin.Instance._translations.SCP999Description;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.Tutorial;
        public override int MaxHealth => 999;
        public override RoomType SpawnRoom => Plugin.Instance.Config.SCP999Room;
        public override float SpawnChance => Plugin.Instance.Config.SCP999SpawnChance;
        public override int MaxCount => Plugin.Instance.Config.SCP999MaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.EnableEffect<CustomPlayerEffects.Disabled>(255, 0);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(RegenerationCoroutine(player));
            player.Scale = new Vector3(1.1f, 0.9f, 1.3f);
            player.IsGodModeEnabled = true;
            player.AddItem(ItemType.KeycardResearchCoordinator);
            if (Plugin.Instance.Config.SCP999XYZEnabled)
            {
                player.Position = Plugin.Instance.Config.SCP999XYZ;
            }
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            player.Scale = Plugin.Instance.Config.size999;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            Exiled.Events.Handlers.Scp330.InteractingScp330 += OnInteractingScp330;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Scp330.InteractingScp330 -= OnInteractingScp330;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
        }

        private void OnInteractingScp330(InteractingScp330EventArgs ev)
        {
            if (Plugin.Instance.customRoles.TryGetValue(ev.Player, out string role) && role == RoleName)
            {
                ev.ShouldSever = false;
                if (!Plugin.Instance.scp330PickupCount.ContainsKey(ev.Player))
                {
                    Plugin.Instance.scp330PickupCount[ev.Player] = 0;
                }

                if (Plugin.Instance.scp330PickupCount[ev.Player] >= 20)
                {
                    ev.IsAllowed = false;
                }
                else
                {
                    Plugin.Instance.scp330PickupCount[ev.Player]++;
                }
            }
        }

        private void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Plugin.Instance.customRoles.TryGetValue(ev.Player, out string role) && role == RoleName && ev.Pickup.Type != ItemType.SCP330 && ev.Pickup.Type != ItemType.KeycardResearchCoordinator)
            {
                ev.IsAllowed = false;
            }
        }

        private IEnumerator<float> RegenerationCoroutine(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                var nearbyPlayers = Player.List.Where(p => Vector3.Distance(p.Position, player.Position) <= 10f);
                foreach (var nearbyPlayer in nearbyPlayers)
                {
                    float distance = Vector3.Distance(nearbyPlayer.Position, player.Position);
                    int healingAmount = GetHealingAmount(distance);

                    if (nearbyPlayer.Health < nearbyPlayer.MaxHealth)
                    {
                        nearbyPlayer.Health += healingAmount;
                        if (nearbyPlayer.Health > nearbyPlayer.MaxHealth)
                        {
                            nearbyPlayer.Health = nearbyPlayer.MaxHealth;
                        }
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }

        private int GetHealingAmount(float distance)
        {
            int healingAmount = Mathf.Clamp(Mathf.RoundToInt(3 * (1 - (distance / 10))), 0, 3);
            return healingAmount;
        }
    }
}

