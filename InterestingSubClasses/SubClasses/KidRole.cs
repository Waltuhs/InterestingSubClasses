using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp330;
using PlayerRoles;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class KidRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.TheKidRoleName;
        public override string Description => Plugin.Instance._translations.TheKidDescription;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 85;
        public override RoomType SpawnRoom => Plugin.Instance.Config.KidRoom;
        public override float SpawnChance => Plugin.Instance.Config.KidSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.KidMaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Scale = Plugin.Instance.Config.KidSize;
            player.EnableEffect<CustomPlayerEffects.MovementBoost>(10, 0);
            if (Plugin.Instance.Config.KidXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.KidXYZ;
            }
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
