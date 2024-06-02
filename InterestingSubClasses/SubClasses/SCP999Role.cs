using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
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
        public override string RoleName => "SCP-999";
        public override string Description => "A friendly SCP that provides passive regeneration to nearby players and can pickup 20 pieces of candy";
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.Tutorial;
        public override int MaxHealth => 999;
        public override RoomType SpawnRoom => RoomType.Lcz330;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(RegenerationCoroutine(player));
            player.Scale = new Vector3(1.2f, 0.9f, 1.3f);
            player.AddItem(ItemType.KeycardResearchCoordinator);
            Door lczdoor = Door.Get(DoorType.Scp330Chamber);
            lczdoor.IsOpen = true;
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            player.Scale = new Vector3(1.0f, 1.0f, 1.0f);
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
