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
        public override string RoleName => "ClassD Informer";
        public override string Description => "A Class-D personnel with access to critical information.";
        public override string abilitydescription => "Receives constant updates on the status of the warhead, SCPs, and NTF remaining.";
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => RoomType.LczClassDSpawn;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(HintStatus(player));
        }

        private IEnumerator<float> HintStatus(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                yield return Timing.WaitForSeconds(10f);
                var warheadStatus = Warhead.Status.ToString();
                var scpsRemaining = Player.List.Count(p => p.Role.Team == Team.SCPs);
                var ntfRemaining = Player.List.Count(p => p.Role.Team == Team.FoundationForces);

                player.ShowHint($"\n\n\n\n\n\n\n\n\n<align=left><voffset=10><color=purple>Warhead</color> Status: {warheadStatus}\n<color=red>SCPs</color> Remaining: {scpsRemaining}\n<color=blue>NTF</color> Remaining: {ntfRemaining}</voffset></align>", 11);
            }
        }
    }
}