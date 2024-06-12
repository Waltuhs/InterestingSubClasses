using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InterestingSubClasses.SubClasses
{
    public class Warden : ISCRoleAPI
    {
        public override string RoleName => Plugin.Instance.Translation.wardenRoleName;
        public override string Description => Plugin.Instance.Translation.wardenDescription;
        public override string abilitydescription => Plugin.Instance.Translation.wardenAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.FacilityGuard;
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.WardenRoom;
        public override float SpawnChance => Plugin.Instance.Config.WardenSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.WardenMaxCount;
        public bool activated = false;
        private int abilityDuration = 5;
        private float regenTime = 10f;
        private int remainingDuration;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            remainingDuration = abilityDuration; 
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(HintCoroutine(player));
            if (Plugin.Instance.Config.WardenXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.WardenXYZ;
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
                if (!activated && remainingDuration > 0)
                {
                    activated = true;
                    Timing.RunCoroutine(ActivateAbility(ev.Player));
                }
                else
                {
                    foreach (Room room in Room.List.Where(current => current.AreLightsOff))
                    {
                        ev.Player.SendFakeSyncVar(room.RoomLightControllerNetIdentity, typeof(RoomLightController), nameof(RoomLightController.NetworkLightsEnabled), false);
                    }
                    activated = false;
                }
            }
        }

        private IEnumerator<float> ActivateAbility(Player player)
        {
            while (activated && remainingDuration > 0)
            {
                foreach (Room room in Room.List.Where(current => current.AreLightsOff))
                {
                    player.SendFakeSyncVar(room.RoomLightControllerNetIdentity, typeof(RoomLightController), nameof(RoomLightController.NetworkLightsEnabled), true);
                }
                player.DisableEffect(EffectType.Flashed);
                remainingDuration--;
                yield return Timing.WaitForSeconds(1f);
            }

            activated = false;
            Timing.RunCoroutine(RegenerateAbility(player));
        }

        private IEnumerator<float> RegenerateAbility(Player player)
        {
            while (remainingDuration < abilityDuration && !activated)
            {
                ShowAbilityStatus(player, remainingDuration);
                yield return Timing.WaitForSeconds(regenTime / abilityDuration);
                remainingDuration++;
            }

            ShowAbilityStatus(player, remainingDuration);
        }

        private IEnumerator<float> HintCoroutine(Player player)
        {
            while (Plugin.Instance.customRoles.TryGetValue(player, out string role) && role == RoleName)
            {
                ShowAbilityStatus(player, remainingDuration);
                yield return Timing.WaitForSeconds(0.7f);
            }
        }

        private void ShowAbilityStatus(Player player, int remainingDuration)
        {
            string cubes = new string('■', remainingDuration) + new string('□', abilityDuration - remainingDuration);
            if (!Plugin.Instance.Config.Broadcasts)
            {
                player.ShowHint($"\n\n\n\n\n\n\n\n\n<align=right><voffset=10><color=purple></color>{Plugin.Instance.Translation.wardenAbilityWord}\n{cubes}</voffset></align>", 1);
            }
            else
            {
                player.Broadcast(1, $"<align=right><voffset=10><color=purple></color>{Plugin.Instance.Translation.wardenAbilityWord}\n{cubes}</voffset></align>");
            }
        }
    }
}
