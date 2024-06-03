using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class JoeBidenRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance._translations.JoeBidenRoleName;
        public override string Description => Plugin.Instance._translations.JoeBidenDescription;
        public override string abilitydescription => "";
        public override RoleTypeId RoleType => RoleTypeId.FacilityGuard;
        public override int MaxHealth => 150; 
        public override RoomType SpawnRoom => RoomType.EzGateB;
        public override float SpawnChance => Plugin.Instance.Config.JoeBidenSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.JoeBidenMaxCount;
        private Vector3 spawnPosition = new Vector3(21.445f, 991.882f, -35.211f);

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Position = spawnPosition;
            player.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            player.ClearInventory();
            player.AddItem(ItemType.GunLogicer);
            player.AddItem(ItemType.ArmorCombat);
            player.AddItem(ItemType.KeycardMTFOperative);
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
