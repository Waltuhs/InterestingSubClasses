using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestingSubClasses.SubClasses
{
    public class GhostRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance.Translation.GhostRoleName;
        public override string Description => Plugin.Instance.Translation.GhostDescription;
        public override string abilitydescription => Plugin.Instance.Translation.GhostAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.GhostRoom;
        public override float SpawnChance => Plugin.Instance.Config.GhostSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.GhostMaxCount;
        private bool isCooldown = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.EnableEffect<CustomPlayerEffects.Disabled>(255, 0);
            if (Plugin.Instance.Config.GhostXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.GhostXYZ;
            }
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.TogglingNoClip += OnTogglingNoClip;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.TogglingNoClip -= OnTogglingNoClip;
        }

        private void OnTogglingNoClip(TogglingNoClipEventArgs ev)
        {
            if (Plugin.Instance.customRoles.TryGetValue(ev.Player, out string role) && role == RoleName)
            {
                if (isCooldown == false)
                {
                    ev.Player.EnableEffect<CustomPlayerEffects.Ghostly>(255, 10);
                    isCooldown = true;
                    Timing.CallDelayed(90f, () => isCooldown = false);
                }
                else
                {
                    string message = Plugin.Instance.Translation.GhostAbilityCooldown.Replace("%n%", "\n");
                    ev.Player.Broadcast(1, message);
                }
            }
        }
    }
}
