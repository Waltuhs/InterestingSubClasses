using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class SCP1058Role : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance.Translation.SCP1058RoleName;
        public override string Description => Plugin.Instance.Translation.SCP1058Description;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.SCP1058Room;
        public override float SpawnChance => Plugin.Instance.Config.SCP1058SpawnChance;
        public override int MaxCount => Plugin.Instance.Config.SCP1058MaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(RandomInvis(player));
            if (Plugin.Instance.Config.SCP1058XYZEnabled)
            {
                player.Position = Plugin.Instance.Config.SCP1058XYZ;
            }
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
        }

        private IEnumerator<float> RandomInvis(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                if (player.Role is FpcRole fpc)
                {
                    fpc.IsInvisible = true;
                    float InvisTime = UnityEngine.Random.Range(10f, 20f);
                    Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(RemainingTimeHint(player, InvisTime));
                    Timing.CallDelayed(InvisTime, () => {
                        fpc.IsInvisible = false;
                    });
                }
                yield return Timing.WaitForSeconds(UnityEngine.Random.Range(90f, 160f));
            }
        }

        private IEnumerator<float> RemainingTimeHint(Player player, float invisTime)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                if (invisTime > 0)
                {
                    string strtime = Math.Round(invisTime).ToString();
                    player.Broadcast(1, Plugin.Instance.Translation.SCP1058InvisibleMessage.Replace("%time", strtime));
                    invisTime -= 1;
                }
                else
                {
                    yield break; 
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
    }
}
