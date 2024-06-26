using CommandSystem;
using Exiled.API.Features;
using InterestingSubClasses.SubClasses;
using RemoteAdmin;
using System;
using System.Linq;

namespace InterestingSubClasses.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SetSubClass : ParentCommand
    {
        public SetSubClass() => LoadGeneratedCommands();

        public override string Command { get; } = "SetSubClass";
        public override string[] Aliases { get; } = new string[] { "SSC" };
        public override string Description { get; } = "Sets the command sender to a specified subclass";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new SetSCP999Command());
            RegisterCommand(new SetKidCommand());
            RegisterCommand(new SetSiteCostumeManagerCommand());
            RegisterCommand(new SetJoeBidenCommand());
            RegisterCommand(new SetClassDInformerCommand());
            RegisterCommand(new SetBusinessmanCommand());
            RegisterCommand(new SetGhostCommand());
            RegisterCommand(new SetLightTechCommand());
            RegisterCommand(new SetSCP1058Command());
            RegisterCommand(new SetTelekineticDboyCommand());
            RegisterCommand(new SeWardenCommand());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "\nPlease enter a valid subcommand:";

            foreach (ICommand command in AllCommands)
            {
                response += $"\n\n<color=blue><b>- {command.Command} {string.Join(", ", command.Aliases)}</b></color> \n<color=white>{command.Description}</color>";
            }
            return false;
        }
    }

    public class SetSCP999Command : ICommand
    {
        public string Command { get; } = "scp999";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the SCP-999 SubClass for the command sender";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.SCP999RoleName}")
            {
                response = "You already have the SCP-999 SubClass";
                return false;
            }

            var scp999Role = Plugin.Instance.registeredRoles.OfType<SCP999Role>().FirstOrDefault();
            if (scp999Role == null)
            {
                response = "SCP-999 role is not enabled or registered";
                return false;
            }

            scp999Role.AddRole(player);
            response = "You have been given the SCP-999 SubClass";
            return true;
        }
    }

    public class SetKidCommand : ICommand
    {
        public string Command { get; } = "kid";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Kid SubClass for the command sender";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.TheKidRoleName}")
            {
                response = "You already have the Kid SubClass";
                return false;
            }

            var kidRole = Plugin.Instance.registeredRoles.OfType<KidRole>().FirstOrDefault();
            if (kidRole == null)
            {
                response = "Kid role is not enabled or registered";
                return false;
            }

            kidRole.AddRole(player);
            response = "You have been given the Kid SubClass";
            return true;
        }
    }

    public class SetSiteCostumeManagerCommand : ICommand
    {
        public string Command { get; } = "sitemanager";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Site Costume Manager SubClass for the command sender";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.SiteCostumeManagerRoleName}")
            {
                response = "You already have the Site Costume Manager SubClass";
                return false;
            }

            var siteCostumeManagerRole = Plugin.Instance.registeredRoles.OfType<SiteCostumeManager>().FirstOrDefault();
            if (siteCostumeManagerRole == null)
            {
                response = "Site Costume Manager role is not enabled or registered";
                return false;
            }

            siteCostumeManagerRole.AddRole(player);
            response = "You have been given the Site Costume Manager SubClass";
            return true;
        }
    }

    public class SetJoeBidenCommand : ICommand
    {
        public string Command { get; } = "joebiden";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Joe Biden SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.JoeBidenRoleName}")
            {
                response = "You already have the Joe Biden SubClass";
                return false;
            }

            var joeBidenRole = Plugin.Instance.registeredRoles.OfType<JoeBidenRole>().FirstOrDefault();
            if (joeBidenRole == null)
            {
                response = "Joe Biden role is not enabled or registered";
                return false;
            }

            joeBidenRole.AddRole(player);
            response = "You have been given the Joe Biden SubClass";
            return true;
        }
    }

    public class SetClassDInformerCommand : ICommand
    {
        public string Command { get; } = "classdinformer";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Class D Informer SubClass for the command sender";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.ClassDInformerRoleName}")
            {
                response = "You already have the Class D Informer SubClass";
                return false;
            }

            var classDInformerRole = Plugin.Instance.registeredRoles.OfType<InformerRole>().FirstOrDefault();
            if (classDInformerRole == null)
            {
                response = "Class D Informer role is not enabled or registered";
                return false;
            }

            classDInformerRole.AddRole(player);
            response = "You have been given the Class D Informer SubClass";
            return true;
        }
    }

    public class SetBusinessmanCommand : ICommand
    {
        public string Command { get; } = "businessman";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Businessman SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.BusinessmanRoleName}")
            {
                response = "You already have the Businessman SubClass";
                return false;
            }

            var businessmanRole = Plugin.Instance.registeredRoles.OfType<BusinessmanRole>().FirstOrDefault();
            if (businessmanRole == null)
            {
                response = "Businessman role is not enabled or registered";
                return false;
            }

            businessmanRole.AddRole(player);
            response = "You have been given the Businessman SubClass";
            return true;
        }
    }

    public class SetGhostCommand : ICommand
    {
        public string Command { get; } = "Ghost";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the Ghost SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.GhostRoleName}")
            {
                response = "You already have the Ghost SubClass";
                return false;
            }

            var GhostRole = Plugin.Instance.registeredRoles.OfType<GhostRole>().FirstOrDefault();
            if (GhostRole == null)
            {
                response = "Ghost role is not enabled or registered";
                return false;
            }

            GhostRole.AddRole(player);
            response = "You have been given the Ghost SubClass";
            return true;
        }
    }

    public class SetLightTechCommand : ICommand
    {
        public string Command { get; } = "LightTech";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the LightTech SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.LightTechnicianRoleName}")
            {
                response = "You already have the LightTech SubClass";
                return false;
            }

            var LightTechtRole = Plugin.Instance.registeredRoles.OfType<LightTechnicianRole>().FirstOrDefault();
            if (LightTechtRole == null)
            {
                response = "LightTech role is not enabled or registered";
                return false;
            }

            LightTechtRole.AddRole(player);
            response = "You have been given the LightTech SubClass";
            return true;
        }
    }

    public class SetSCP1058Command : ICommand
    {
        public string Command { get; } = "SCP1058";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the SCP1058 SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.SCP1058RoleName}")
            {
                response = "You already have the SCP1058 SubClass";
                return false;
            }

            var SCP1058Role = Plugin.Instance.registeredRoles.OfType<SCP1058Role>().FirstOrDefault();
            if (SCP1058Role == null)
            {
                response = "SCP1058 role is not enabled or registered";
                return false;
            }

            SCP1058Role.AddRole(player);
            response = "You have been given the SCP1058 SubClass";
            return true;
        }
    }

    public class SetTelekineticDboyCommand : ICommand
    {
        public string Command { get; } = "TelekineticDboy";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the TelekineticDboy SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.TelekineticDboyRoleName}")
            {
                response = "You already have the TelekineticDboy SubClass";
                return false;
            }

            var TelekineticDboy = Plugin.Instance.registeredRoles.OfType<TelekineticDboyRole>().FirstOrDefault();
            if (TelekineticDboy == null)
            {
                response = "TelekineticDboy role is not enabled or registered";
                return false;
            }

            TelekineticDboy.AddRole(player);
            response = "You have been given the TelekineticDboy SubClass";
            return true;
        }
    }

        public class SeWardenCommand : ICommand
    {
        public string Command { get; } = "warden";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Sets the warden SubClass for the command sender.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be run by a player";
                return false;
            }

            Player player = Player.Get(playerSender);

            if (Plugin.Instance.customRoles.TryGetValue(player, out string currentRole) && currentRole == $"{Plugin.Instance.Translation.TelekineticDboyRoleName}")
            {
                response = "You already have the warden SubClass";
                return false;
            }

            var warden = Plugin.Instance.registeredRoles.OfType<Warden>().FirstOrDefault();
            if (warden == null)
            {
                response = "warden role is not enabled or registered";
                return false;
            }

            warden.AddRole(player);
            response = "You have been given the warden SubClass";
            return true;
        }
        public bool SanitizeResponse { get; } = true;
    }
}

