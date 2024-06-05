using Exiled.API.Enums;
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

        [Description("SCP-999 spawn room")]
        public RoomType SCP999Room { get; set; } = RoomType.LczCafe;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool SCP999XYZEnabled { get; set; } = false;

        [Description("XYZ to spawn SCP-999 at if its enabled")]
        public Vector3 SCP999XYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Kid role")]
        public bool KidRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Kid role (0.0 to 1.0) (0.50 = 50%)")]
        public float KidSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Kid role")]
        public int KidMaxCount { get; set; } = 1;

        [Description("Kid spawn room")]
        public RoomType KidRoom { get; set; } = RoomType.LczToilets;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool KidXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn Kid at if its enabled")]
        public Vector3 KidXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Site Costume Manager role")]
        public bool SiteCostumeManagerRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Site Costume Manager role (0.0 to 1.0) (0.50 = 50%)")]
        public float SiteCostumeManagerSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Site Costume Manager role")]
        public int SiteCostumeManagerMaxCount { get; set; } = 1;

        [Description("Costume spawn room")]
        public RoomType CostumeRoom { get; set; } = RoomType.Lcz914;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool CostumeXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn Costume at if its enabled")]
        public Vector3 CostumeXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Joe Biden role")]
        public bool JoeBidenRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Joe Biden role (0.0 to 1.0) (0.50 = 50%)")]
        public float JoeBidenSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Joe Biden role")]
        public int JoeBidenMaxCount { get; set; } = 1;

        [Description("Joe spawn room")]
        public RoomType JoeRoom { get; set; } = RoomType.EzGateB;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool JoeXYZEnabled { get; set; } = true;

        [Description("XYZ to spawn Joe at if its enabled")]
        public Vector3 JoeXYZ { get; set; } = new Vector3(21.445f, 991.882f, -35.211f);

        [Description("Enable or disable Businessman role")]
        public bool BusinessmanRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Businessman role (0.0 to 1.0) (0.50 = 50%)")]
        public float BusinessmanSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Businessman role")]
        public int BusinessmanMaxCount { get; set; } = 1;

        [Description("Businessman spawn room")]
        public RoomType BusRoom { get; set; } = RoomType.LczGlassBox;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool BusXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn Businessman at if its enabled")]
        public Vector3 BusXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Informer role")]
        public bool InformerRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Informer role (0.0 to 1.0) (0.50 = 50%)")]
        public float InformerSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Informer role")]
        public int InformerMaxCount { get; set; } = 1;

        [Description("Informer spawn room")]
        public RoomType InformerRoom { get; set; } = RoomType.LczClassDSpawn;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool InformerXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn Informer at if its enabled")]
        public Vector3 InformerXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Ghost role")]
        public bool GhostRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Ghost role (0.0 to 1.0) (0.50 = 50%)")]
        public float GhostSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Ghost role")]
        public int GhostMaxCount { get; set; } = 1;

        [Description("Ghost spawn room")]
        public RoomType GhostRoom { get; set; } = RoomType.LczClassDSpawn;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool GhostXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn Ghost at if its enabled")]
        public Vector3 GhostXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable Light Technician role")]
        public bool LightTechnicianRoleEnabled { get; set; } = true;

        [Description("The spawn chance for Light Technician role (0.0 to 1.0) (0.50 = 50%)")]
        public float LightTechnicianSpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the Light Technician role")]
        public int LightTechnicianMaxCount { get; set; } = 1;

        [Description("LightTech spawn room")]
        public RoomType LightTechRoom { get; set; } = RoomType.EzCafeteria;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool LightTechXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn LightTech at if its enabled")]
        public Vector3 LightTechXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable SCP1058 role")]
        public bool SCP1058RoleEnabled { get; set; } = true;

        [Description("The spawn chance for SCP1058 role (0.0 to 1.0) (0.50 = 50%)")]
        public float SCP1058SpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the SCP1058 role")]
        public int SCP1058MaxCount { get; set; } = 1;

        [Description("SCP1058 spawn room")]
        public RoomType SCP1058Room { get; set; } = RoomType.LczClassDSpawn;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool SCP1058XYZEnabled { get; set; } = false;

        [Description("XYZ to spawn SCP1058 at if its enabled")]
        public Vector3 SCP1058XYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Enable or disable TelekineticDboy role")]
        public bool TelekineticDboyRoleEnabled { get; set; } = true;

        [Description("The spawn chance for TelekineticDboy role (0.0 to 1.0) (0.50 = 50%)")]
        public float TelekineticDboySpawnChance { get; set; } = 0.50f;

        [Description("The maximum number of players that can be assigned the TelekineticDboy role")]
        public int TelekineticDboyMaxCount { get; set; } = 1;

        [Description("TelekineticDboy spawn room")]
        public RoomType TelekineticDboyRoom { get; set; } = RoomType.LczClassDSpawn;

        [Description("Whether the xyz spawn overrides the room spawn")]
        public bool TelekineticDboyXYZEnabled { get; set; } = false;

        [Description("XYZ to spawn TelekineticDboy at if its enabled")]
        public Vector3 TelekineticDboyXYZ { get; set; } = new Vector3(9f, 9f, 9f);

        [Description("Should hints be broadcasts instead?")]
        public bool Broadcasts { get; set; } = false;

        [Description("Kid size")]
        public Vector3 KidSize { get; set; } = new Vector3(1.1f, 0.8f, 1.1f);

        [Description("SCP-999 size")]
        public Vector3 size999 { get; set; } = new Vector3(1.1f, 0.9f, 1.3f);
    }
}
