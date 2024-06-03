using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
namespace InterestingSubClasses.SubClasses
{
    public class BusinessmanRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.BusinessmanRoleName;
        public override string Description => Plugin.Instance._translations.BusinessmanDescription;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.Scientist;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => RoomType.LczGlassBox;
        public override float SpawnChance => Plugin.Instance.Config.BusinessmanSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.BusinessmanMaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(GenerateCoins(player));
        }

        private IEnumerator<float> GenerateCoins(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                player.AddItem(ItemType.Coin);
                yield return Timing.WaitForSeconds(30f);
            }
        }
    }
}

