using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorUtils;
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
    public class TelekineticDboyRole : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance.Translation.TelekineticDboyRoleName;
        public override string Description => Plugin.Instance.Translation.TelekineticDboyDescription;
        public override string abilitydescription => Plugin.Instance.Translation.TelekineticDboyAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.ClassD;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.TelekineticDboyRoom;
        public override float SpawnChance => Plugin.Instance.Config.TelekineticDboySpawnChance;
        public override int MaxCount => Plugin.Instance.Config.TelekineticDboyMaxCount;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            if (Plugin.Instance.Config.TelekineticDboyXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.TelekineticDboyXYZ;
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
                if (!Physics.Raycast(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward, out RaycastHit raycastHit, 70f, ~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)))
                    return;

                Open(ev.Player, raycastHit.transform.gameObject);
            }
        }

        private void Open(Player player, GameObject gameobject)
        {
            if (gameobject.GetComponentInParent<RegularDoorButton>() is RegularDoorButton button)
            {
                Door door = Door.Get(button.GetComponentInParent<DoorVariant>());
                if (door is null || door.IsMoving || (door.IsLocked && !player.IsBypassModeEnabled) || (door.IsCheckpoint && door.IsOpen))
                    return;

                if (door.IsKeycardDoor && (!player.Items.Any(item => item is Keycard keycard && (keycard.Base.Permissions & door.RequiredPermissions.RequiredPermissions) != 0)))
                {
                    player.Broadcast(1, Plugin.Instance.Translation.TelekineticDboyAbilityDenied);
                    return;
                }

                if (door.IsOpen)
                {
                    door.IsOpen = false;
                }
                else
                {
                    door.IsOpen = true;
                }
            }
        }
    }
}
