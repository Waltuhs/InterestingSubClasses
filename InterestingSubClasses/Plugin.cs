using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Server;
using HarmonyLib;
using InterestingSubClasses.SubClasses;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestingSubClasses
{
    public class Plugin : Plugin<Config, Translations>
    {
        public static Plugin Instance { get; private set; } = null;
        public override string Author => "sexy waltuh";
        public override string Name => "InterestingSubClasses";
        public override string Prefix => "ISC";
        public override Version RequiredExiledVersion => new Version(8, 9, 5);
        public override Version Version => new Version(2, 2, 2);
        public List<ISCRoleAPI> registeredRoles = new List<ISCRoleAPI>();
        public Dictionary<Player, string> customRoles = new Dictionary<Player, string>();
        public Dictionary<Player, CoroutineHandle> activeCoroutines = new Dictionary<Player, CoroutineHandle>();
        public Dictionary<Player, int> scp330PickupCount = new Dictionary<Player, int>();
        public Translations _translations = new Translations();
        private Harmony _harmony;

        public override void OnEnabled()
        {
            Instance = this;
            _harmony = new Harmony($"com.{Author}.{Name}");
            _harmony.PatchAll();
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
            if (Config.BusinessmanRoleEnabled)
            {
                RegisterRole(new BusinessmanRole());
            }
            if (Config.InformerRoleEnabled)
            {
                RegisterRole(new InformerRole());
            }
            if (Config.GhostRoleEnabled)
            {
                RegisterRole(new GhostRole());
            }
            if (Config.LightTechnicianRoleEnabled)
            {
                RegisterRole(new LightTechnicianRole());
            }
            if (Config.SCP1058RoleEnabled)
            {
                RegisterRole(new SCP1058Role());
            }
            if (Config.TelekineticDboyRoleEnabled)
            {
                RegisterRole(new TelekineticDboyRole());
            }
            ServerConsole.AddLog("[ISC] Roles registered.", ConsoleColor.DarkBlue);
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound -= OnRoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            _harmony.UnpatchAll($"com.{Author}.{Name}");
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound -= OnRoundEnded;
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
                ServerConsole.AddLog("[ISC] Not enough players to enable subclasses.", ConsoleColor.Red);
                return;
            }

            var availablePlayers = Player.List.ToList();
            var assignedRoles = new Dictionary<ISCRoleAPI, int>();

            foreach (var role in registeredRoles)
            {
                assignedRoles[role] = 0;
            }

            foreach (var role in registeredRoles)
            {
                var shuffledPlayers = availablePlayers.OrderBy(_ => UnityEngine.Random.value).ToList();

                foreach (var player in shuffledPlayers)
                {
                    if (assignedRoles[role] >= role.MaxCount)
                        break;

                    if (CanAssignRole(player, role.RoleType) && UnityEngine.Random.value <= role.SpawnChance)
                    {
                        role.AddRole(player);
                        assignedRoles[role]++;
                        availablePlayers.Remove(player);
                    }
                }
            }

            if (Config.SCP999RoleEnabled)
            {
                var classDPlayersWithoutRoles = availablePlayers
                    .Where(p => p.Role == RoleTypeId.ClassD)
                    .ToList();

                if (classDPlayersWithoutRoles.Count > 2 && assignedRoles[registeredRoles.OfType<SCP999Role>().FirstOrDefault()] < Config.SCP999MaxCount)
                {
                    var randomClassD = classDPlayersWithoutRoles[UnityEngine.Random.Range(0, classDPlayersWithoutRoles.Count)];
                    if (UnityEngine.Random.value <= Config.SCP999SpawnChance)
                    {
                        registeredRoles.OfType<SCP999Role>().FirstOrDefault()?.AddRole(randomClassD);
                    }
                }
            }
        }

        private bool CanAssignRole(Player player, RoleTypeId roleType)
        {
            return player.Role == roleType;
        }

        private void OnRoundEnded()
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

