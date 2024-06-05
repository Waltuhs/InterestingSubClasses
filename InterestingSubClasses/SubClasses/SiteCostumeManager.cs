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
        public override string RoleName => Plugin.Instance._translations.SiteCostumeManagerRoleName;
        public override string Description => Plugin.Instance._translations.SiteCostumeManagerDescription;
        public override string abilitydescription => Plugin.Instance._translations.SiteCostumeManagerAbilityDescription;
        public override RoleTypeId RoleType => RoleTypeId.Scientist; 
        public override int MaxHealth => 100;
        public override RoomType SpawnRoom => Plugin.Instance.Config.CostumeRoom;
        public override float SpawnChance => Plugin.Instance.Config.SiteCostumeManagerSpawnChance;
        public override int MaxCount => Plugin.Instance.Config.SiteCostumeManagerMaxCount;
        private Dictionary<Player, RoleTypeId> originalAppearances = new Dictionary<Player, RoleTypeId>();
        private bool isCooldown = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            if (Plugin.Instance.Config.CostumeXYZEnabled)
            {
                player.Position = Plugin.Instance.Config.CostumeXYZ;
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
                if (isCooldown == false)
                {
                    DisguisePlayersInRoom(ev.Player);
                    isCooldown = true;
                    Timing.CallDelayed(120f, () => isCooldown = false);
                }
                else
                {
                    string message = Plugin.Instance.Translation.SiteCostumeManagerAbilityCooldown.Replace("%n%", "\n");
                    ev.Player.Broadcast(1, message);
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
    }
}
