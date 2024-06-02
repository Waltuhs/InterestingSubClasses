using Exiled.API.Interfaces;
using System.ComponentModel;

namespace InterestingSubClasses
{
    public sealed class Config : IConfig
    {
        [Description("is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("is Debug mode enabled?")]
        public bool Debug { get; set; } = false;

        [Description("The minimum number of players required to enable subclasses.")]
        public int MinPlayersForSubclasses { get; set; } = 4;

        [Description("Is the business man SubClass enabled?")]
        public bool businessmanRoleEnabled { get; set; } = true;

        [Description("Is the Informer SubClass enabled?")]
        public bool InformerRoleEnabled { get; set; } = true;

        [Description("Is the JoeBiden SubClass enabled?")]
        public bool JoeBidenRoleEnabled { get; set; } = true;

        [Description("Is the Kid SubClass enabled?")]
        public bool KidRoleEnabled { get; set; } = true;

        [Description("Is the SCP999 SubClass enabled?")]
        public bool SCP999RoleEnabled { get; set; } = true;

        [Description("Is the SiteCostumeManager SubClass enabled?")]
        public bool SiteCostumeManagerRoleEnabled { get; set; } = true;
    }
}
