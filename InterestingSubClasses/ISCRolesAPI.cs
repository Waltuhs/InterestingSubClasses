using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
using System.Linq;

namespace InterestingSubClasses
{
    public abstract class ISCRoleAPI
    {
        public abstract string RoleName { get; }
        public abstract string Description { get; }
        public abstract string abilitydescription { get; }
        public abstract RoleTypeId RoleType { get; }
        public abstract int MaxHealth { get; }
        public abstract RoomType SpawnRoom { get; }

        public virtual void AddRole(Player player)
        {
            Log.Info($"Setting role {RoleName} for player {player.Nickname}.");
            Plugin.Instance.customRoles[player] = RoleName;
            player.Role.Set(RoleType);
            player.Health = MaxHealth;
            player.MaxHealth = MaxHealth;
            player.CustomInfo = RoleName;
            player.Teleport(SpawnRoom);
            player.ShowHint($"\n\nYou've been set to\n{RoleName}\n{Description}\n{abilitydescription}", 5);
            Exiled.Events.Handlers.Player.Died += OnPlayerDied;
            Exiled.Events.Handlers.Server.EndingRound += OnRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            SubscribeEvents();
        }

        public virtual void RemoveRole(Player player)
        {
            Log.Info($"Removing role {RoleName} from player {player.Nickname}.");
            if (Plugin.Instance.customRoles.ContainsKey(player))
            {
                Plugin.Instance.customRoles.Remove(player);
                if (Plugin.Instance.activeCoroutines.ContainsKey(player))
                {
                    Timing.KillCoroutines(Plugin.Instance.activeCoroutines[player]);
                    Plugin.Instance.activeCoroutines.Remove(player);
                }
            }
            UnsubscribeEvents();
        }

        private void OnPlayerDied(DiedEventArgs ev)
        {
            RemoveRole(ev.Player);
        }

        private void OnRoundEnded(EndingRoundEventArgs ev)
        {
            UnsubscribeEvents();
        }

        private void OnRoundStarted()
        {
            var players = Player.List.ToList();
            if (players.Count == 0)
                return;

            var randomPlayer = players[UnityEngine.Random.Range(0, players.Count)];
            Log.Info($"Assigning role {RoleName} to random player {randomPlayer.Nickname} at round start.");
            AddRole(randomPlayer);
        }

        protected virtual void SubscribeEvents() { }
        protected virtual void UnsubscribeEvents() { }
    }
}
