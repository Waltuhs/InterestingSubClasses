using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
namespace InterestingSubClasses.SubClasses
{
    public class BusinessmanRole : ISCRoleAPI
    {
        public override string RoleName => "Businessman";
        public override string Description => "A savvy individual who generates 1 coin every 30 seconds.";
        public override string abilitydescription => "generates 1 coin every 30 seconds";
        public override RoleTypeId RoleType => RoleTypeId.Scientist;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => RoomType.LczGlassBox;

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
