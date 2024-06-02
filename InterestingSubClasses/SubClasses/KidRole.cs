using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp330;
using PlayerRoles;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class KidRole : ISCRoleAPI
    {
        public override string RoleName => "The Kid";
        public override string Description => "A kid that spawns in SCP-330 and can pick up 5 candies";
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 85;
        public override RoomType SpawnRoom => RoomType.Lcz330;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Scale = new Vector3(1.1f, 0.8f, 1.1f);
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            player.Scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Scp330.InteractingScp330 += OnInteractingScp330;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Scp330.InteractingScp330 -= OnInteractingScp330;
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

                if (Plugin.Instance.scp330PickupCount[ev.Player] >= 5)
                {
                    ev.ShouldSever = true;
                }
                else
                {
                    Plugin.Instance.scp330PickupCount[ev.Player]++;
                }
            }
        }
    }
}
