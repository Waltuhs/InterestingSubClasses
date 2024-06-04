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
        public override string RoleName => Plugin.Instance._translations.GhostRoleName;
        public override string Description => Plugin.Instance._translations.GhostDescription;
        public override string abilitydescription => Plugin.Instance._translations.GhostAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => RoomType.LczClassDSpawn;
        public override float SpawnChance => Plugin.Instance.Config.GhostSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.GhostMaxCount;
        private bool isCooldown = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.EnableEffect<CustomPlayerEffects.Disabled>(255, 0);
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
                    GiveGhostly(ev.Player);
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

        private void GiveGhostly(Player player) 
        {
            player.EnableEffect<CustomPlayerEffects.Ghostly>(255, 10);
        }
    }
}
