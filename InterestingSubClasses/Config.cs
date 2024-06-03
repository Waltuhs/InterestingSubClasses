using Exiled.API.Interfaces;
using System.ComponentModel;
using UnityEngine;

namespace InterestingSubClasses
{
    public sealed class Config : IConfig
    {
        [Description("is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("is Debug mode enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Minimum number of players required for subclasses to be enabled")]
        public int MinPlayersForSubclasses { get; set; } = 5;

        [Description("Enable or disable SCP-999 role")]
        public bool SCP999RoleEnabled { get; set; } = true;

        [Description("The spawn chance for SCP-999 role (0.0 to 1.0) (0.50 = 50%)")]
        public float SCP999SpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the SCP-999 role")]
        public int SCP999MaxCount { get; set; } = 1;

        [Description("Enable or disable Kid role")]
        public bool KidRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Kid role (0.0 to 1.0) (0.50 = 50%)")]
        public float KidSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Kid role")]
        public int KidMaxCount { get; set; } = 1;

        [Description("Enable or disable Site Costume Manager role")]
        public bool SiteCostumeManagerRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Site Costume Manager role (0.0 to 1.0) (0.50 = 50%)")]
        public float SiteCostumeManagerSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Site Costume Manager role")]
        public int SiteCostumeManagerMaxCount { get; set; } = 1;

        [Description("Enable or disable Joe Biden role")]
        public bool JoeBidenRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Joe Biden role (0.0 to 1.0) (0.50 = 50%)")]
        public float JoeBidenSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Joe Biden role")]
        public int JoeBidenMaxCount { get; set; } = 1;

        [Description("Enable or disable Businessman role")]
        public bool BusinessmanRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Businessman role (0.0 to 1.0) (0.50 = 50%)")]
        public float BusinessmanSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Businessman role")]
        public int BusinessmanMaxCount { get; set; } = 1;

        [Description("Enable or disable Informer role")]
        public bool InformerRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Informer role (0.0 to 1.0) (0.50 = 50%)")]
        public float InformerSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Informer role")]
        public int InformerMaxCount { get; set; } = 1;

        [Description("Should hints be broadcasts instead?")]
        public bool Broadcasts { get; set; } = false;

        [Description("Kid size")]
        public Vector3 KidSize { get; set; } = new Vector3(1.1f, 0.8f, 1.1f);

        [Description("SCP-999 size")]
        public Vector3 size999 { get; set; } = new Vector3(1.1f, 0.9f, 1.3f);
    }
}
