using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using InterestingSubClasses.SubClasses;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestingSubClasses
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; } = null;
        public override string Author => "sexy waltuh";
        public override string Name => "InterestingSubClasses";
        public override string Prefix => "ISC";
        public override Version Version => new Version(1, 0, 0);
        private List<ISCRoleAPI> registeredRoles = new List<ISCRoleAPI>();
        public Dictionary<Player, string> customRoles = new Dictionary<Player, string>();
        public Dictionary<Player, CoroutineHandle> activeCoroutines = new Dictionary<Player, CoroutineHandle>();
        public Dictionary<Player, int> scp330PickupCount = new Dictionary<Player, int>();

        public override void OnEnabled()
        {
            Instance = this;
            ServerConsole.AddLog("[ISC] Registering roles...", ConsoleColor.DarkBlue);
            if (Config.SCP999RoleEnabled)
            {
                RegisterRole(new SCP999Role());
            }
            if (Config.KidRoleEnabled)
            {
                RegisterRole(new KidRole());
            }
            if (Config.SiteCostumeManagerRoleEnabled)
            {
                RegisterRole(new SiteCostumeManager());
            }
            if (Config.JoeBidenRoleEnabled)
            {
                RegisterRole(new JoeBidenRole());
            }
            if (Config.businessmanRoleEnabled)
            {
                RegisterRole(new BusinessmanRole());
            }
            if (Config.InformerRoleEnabled)
            {
                RegisterRole(new InformerRole());
            }
            ServerConsole.AddLog("[ISC] Roles registered.", ConsoleColor.DarkBlue);
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.EndingRound -= OnRoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.EndingRound -= OnRoundEnded;
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterRole(ISCRoleAPI role)
        {
            registeredRoles.Add(role);
            ServerConsole.AddLog($"[ISC] {role.RoleName} has been registered.", ConsoleColor.DarkBlue);
        }

        private void OnRoundStarted()
        {
            if (Player.List.Count() < Config.MinPlayersForSubclasses)
            {
                ServerConsole.AddLog("<color=red>[ISC]</color> Not enough players to enable subclasses.", ConsoleColor.Red);
                return;
            }

            var availablePlayers = Player.List.ToList();
            var assignedRoles = new HashSet<Player>();

            foreach (var role in registeredRoles)
            {
                var roleAssigned = false;
                var shuffledPlayers = availablePlayers.OrderBy(_ => UnityEngine.Random.value).ToList();

                foreach (var player in shuffledPlayers)
                {
                    if (assignedRoles.Contains(player))
                        continue;

                    if (CanAssignRole(player, role.RoleType))
                    {
                        role.AddRole(player);
                        assignedRoles.Add(player);
                        roleAssigned = true;
                        break;
                    }
                }

                if (!roleAssigned)
                {
                    ServerConsole.AddLog($"<color=red>[ISC]</color> No suitable player found for role {role.RoleName}.", ConsoleColor.Yellow);
                }
            }
            var classDPlayersWithoutRoles = availablePlayers
                .Where(p => p.Role == RoleTypeId.ClassD && !assignedRoles.Contains(p))
                .ToList();

            if (classDPlayersWithoutRoles.Count > 2 && Config.SCP999RoleEnabled)
            {
                var randomClassD = classDPlayersWithoutRoles[UnityEngine.Random.Range(0, classDPlayersWithoutRoles.Count)];
                registeredRoles.OfType<SCP999Role>().FirstOrDefault()?.AddRole(randomClassD);
            }
        }

        private bool CanAssignRole(Player player, RoleTypeId roleType)
        {
            return player.Role == roleType;
        }

        private void OnRoundEnded(EndingRoundEventArgs ev)
        {
            foreach (var coroutine in activeCoroutines.Values)
            {
                Timing.KillCoroutines(coroutine);
            }
            customRoles.Clear();
            scp330PickupCount.Clear();
            activeCoroutines.Clear();
        }
    }
}
