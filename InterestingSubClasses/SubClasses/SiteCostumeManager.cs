using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;

namespace InterestingSubClasses.SubClasses
{
    public class SiteCostumeManager : ISCRoleAPI
    {
        public override string RoleName => "Site Costume Manager";
        public override string Description => "Can disguise all people in the same room as him as scientists for a minute.";
        public override string abilitydescription => "Press ALT to disguise everyone in the room your in as a scientist";
        public override RoleTypeId RoleType => RoleTypeId.Scientist; 
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => RoomType.Lcz914;
        private readonly Dictionary<Player, RoleTypeId> originalAppearances = new Dictionary<Player, RoleTypeId>();
        private bool isCooldown = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            Plugin.Instance.activeCoroutines[player] = Timing.RunCoroutine(CooldownCoroutine());
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
                    DisguisePlayersInRoom(ev.Player);
                    isCooldown = true;
                    Timing.CallDelayed(60f, () => isCooldown = false);
                }
                else
                {
                    ev.Player.Broadcast(1, "ability under cooldown \n default cooldown = 120 seconds");
                }
            }
        }

        private void DisguisePlayersInRoom(Player manager)
        {
            var room = manager.CurrentRoom;

            if (room == null)
                return;

            var playersInRoom = Player.List.Where(p => p.CurrentRoom == room && p != manager).ToList();
            originalAppearances.Clear();

            foreach (var player in playersInRoom)
            {
                originalAppearances[player] = player.Role; 
                player.ChangeAppearance(RoleTypeId.Scientist); 
            }
            Timing.CallDelayed(60f, () => RevertDisguise(playersInRoom));
        }

        private void RevertDisguise(List<Player> players)
        {
            foreach (var player in players)
            {
                if (originalAppearances.ContainsKey(player))
                {
                    player.ChangeAppearance(originalAppearances[player]);
                }
            }
            originalAppearances.Clear();
        }

        private IEnumerator<float> CooldownCoroutine()
        {
            yield return Timing.WaitForSeconds(120f); 
            if (isCooldown)
            {
                isCooldown = false;
            }
        }
    }
}