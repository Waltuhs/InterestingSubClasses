using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.EventArgs.Scp173;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class SCP999Role : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.SCP999RoleName;
        public override string Description => Plugin.Instance._translations.SCP999Description;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.Tutorial;
        public override int MaxHealth => 999;
        public override RoomType SpawnRoom => RoomType.LczCafe;
        public override float SpawnChance => Plugin.Instance.Config.SCP999SpawnChance;
        public override int MaxCount => Plugin.Instance.Config.SCP999MaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            ApplyDisabledEffect(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(RegenerationCoroutine(player));
            player.Scale = new Vector3(1.1f, 0.9f, 1.3f);
            player.IsGodModeEnabled = true;
            player.AddItem(ItemType.KeycardResearchCoordinator);
        }

        private void ApplyDisabledEffect(Player player)
        {
            player.EnableEffect<CustomPlayerEffects.Disabled>(255, 0);
        }

        private void RemoveDisabledEffect(Player player)
        {
            player.DisableEffect<CustomPlayerEffects.Disabled>();
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            RemoveDisabledEffect(player);
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
                    if (nearbyPlayer.Health < nearbyPlayer.MaxHealth)
                    {
                        nearbyPlayer.Health += 1;
                    }
                }
                yield return Timing.WaitForSeconds(3f);
            }
        }
    }
}

