using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class JoeBidenRole : ISCRoleAPI
    {
        public override string RoleName => "Joe Biden";
        public override string Description => "A guard with a 20% slowness effect but enhanced firepower.";
        public override string abilitydescription => "adds 20% slowness but also gives better firepower on spawn";
        public override RoleTypeId RoleType => RoleTypeId.FacilityGuard;
        public override int MaxHealth => 150; 
        public override RoomType SpawnRoom => RoomType.EzGateB;
        private Vector3 spawnPosition = new Vector3(21.445f, 991.882f, -35.211f);

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Position = spawnPosition;
            player.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            player.ClearInventory();
            player.AddItem(ItemType.GunLogicer);
            player.AddItem(ItemType.ArmorCombat);
            player.AddItem(ItemType.KeycardGuard);
            player.AddItem(ItemType.Medkit);
            player.AddAmmo(AmmoType.Nato762, 150);
            ApplyDisabledEffect(player);
        }

        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            RemoveDisabledEffect(player);
            player.Scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        private void ApplyDisabledEffect(Player player)
        {
            player.EnableEffect<CustomPlayerEffects.Disabled>(255, 0);
        }

        private void RemoveDisabledEffect(Player player)
        {
            player.DisableEffect<CustomPlayerEffects.Disabled>();
        }
    }
}
