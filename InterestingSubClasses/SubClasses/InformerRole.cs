using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestingSubClasses.SubClasses
{
    public class InformerRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.ClassDInformerRoleName;
        public override string Description => Plugin.Instance._translations.ClassDInformerDescription;
        public override string abilitydescription => Plugin.Instance._translations.ClassDInformerAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.InformerRoom;
        public override float SpawnChance => Plugin.Instance.Config.InformerSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.InformerMaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(HintStatus(player));
            if (Plugin.Instance.Config.InformerXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.InformerXYZ;
            }
        }

        private IEnumerator<float> HintStatus(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                yield return Timing.WaitForSeconds(10f);
                var warheadStatus = Warhead.Status.ToString();
                var scpsRemaining = Player.List.Count(p => p.Role.Team == Team.SCPs);
                var ntfRemaining = Player.List.Count(p => p.Role.Team == Team.FoundationForces);
                if (Plugin.Instance.Config.Broadcasts == false)
                {
                    player.ShowHint($"\n\n\n\n\n\n\n\n\n<align=left><voffset=10><color=purple>Warhead</color>: {warheadStatus}\n<color=red>SCPs</color>: {scpsRemaining}\n<color=blue>NTF</color>: {ntfRemaining}</voffset></align>", 11);
                }
                else
                {
                    player.Broadcast(11, $"<align=left><voffset=10><color=purple>Warhead</color>: {warheadStatus}\n<color=red>SCPs</color>: {scpsRemaining} <color=blue>NTF</color>: {ntfRemaining}</voffset></align>");
                }
            }
        }
    }
}