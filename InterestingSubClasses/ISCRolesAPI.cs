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
        public abstract float SpawnChance { get; }
        public abstract int MaxCount { get; }

        public virtual void AddRole(Player player)
        {
            Plugin.Instance.customRoles[player] = RoleName;
            player.Role.Set(RoleType);
            player.Health = MaxHealth;
            player.MaxHealth = MaxHealth;
            player.CustomInfo = RoleName;
            player.Teleport(SpawnRoom);
            if (Plugin.Instance.Config.Broadcasts == false)
            {
                player.ShowHint($"\n\n{Plugin.Instance.Translation.SubClassSpawnHint}\n{RoleName}\n{Description}\n{abilitydescription}", 5);
            }
            else
            {
                player.Broadcast(5, $"\n\n{Plugin.Instance.Translation.SubClassSpawnHint}\n{RoleName}\n{Description}\n{abilitydescription}");
            }
            SubscribeToEvents();
        }

        public virtual void RemoveRole(Player player)
        {
            if (Plugin.Instance.customRoles.ContainsKey(player))
            {
                Plugin.Instance.customRoles.Remove(player);
                if (Plugin.Instance.activeCoroutines.ContainsKey(player))
                {
                    Timing.KillCoroutines(Plugin.Instance.activeCoroutines[player]);
                    Plugin.Instance.activeCoroutines.Remove(player);
                }
            }
            UnsubscribeFromEvents();
        }

        private void OnPlayerDied(DiedEventArgs ev)
        {
            RemoveRole(ev.Player);
            UnsubscribeFromEvents();
        }

        private void OnRoundEnded(EndingRoundEventArgs ev)
        {
            UnsubscribeFromEvents();
        }

        private void OnChangingRole(ChangingRoleEventArgs ev)
        {
            RemoveRole(ev.Player);
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            Exiled.Events.Handlers.Player.Died += OnPlayerDied;
            Exiled.Events.Handlers.Server.EndingRound += OnRoundEnded;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            SubscribeEvents();
        }

        private void UnsubscribeFromEvents()
        {
            Exiled.Events.Handlers.Player.Died -= OnPlayerDied;
            Exiled.Events.Handlers.Server.EndingRound -= OnRoundEnded;
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            UnsubscribeEvents();
        }

        protected virtual void SubscribeEvents() { }
        protected virtual void UnsubscribeEvents() { }
    }
}
