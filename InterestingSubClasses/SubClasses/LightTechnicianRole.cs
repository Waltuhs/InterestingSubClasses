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
using Telepathy;

namespace InterestingSubClasses.SubClasses
{
    public class LightTechnicianRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.LightTechnicianRoleName;
        public override string Description => Plugin.Instance._translations.LightTechnicianDescription;
        public override string abilitydescription => Plugin.Instance._translations.LightTechnicianAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.FacilityGuard;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.LightTechRoom;
        public override float SpawnChance => Plugin.Instance.Config.LightTechnicianSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.LightTechnicianMaxCount;
        private bool isCooldown = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            if (Plugin.Instance.Config.LightTechXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.LightTechXYZ;
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
                    TurnOffLightsInCurrentRoom(ev.Player);
                    isCooldown = true;
                    Timing.CallDelayed(120f, () => isCooldown = false);
                }
                else
                {
                    string message = Plugin.Instance.Translation.LightTechnicianAbilityCooldown.Replace("%n%", "\n");
                    ev.Player.Broadcast(1, message);
                }
            }
        }

        private void TurnOffLightsInCurrentRoom(Player player)
        {
            Room room = player.CurrentRoom;
            if (room != null)
            {
                room.TurnOffLights(20f);
            }
        }
    }
}
