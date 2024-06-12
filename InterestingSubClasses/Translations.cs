using Exiled.API.Interfaces;

namespace InterestingSubClasses
{
    public class Translations : ITranslation
    {
        public string SubClassSpawnHint { get; set; } = "You've been set to";

        public string SiteCostumeManagerRoleName { get; set; } = "Site Costume Manager";
        public string SiteCostumeManagerDescription { get; set; } = "Can disguise all people in the same room as him as scientists for a minute";
        public string SiteCostumeManagerAbilityDescription { get; set; } = "Press ALT to disguise everyone in the room you're in as a scientist";
        public string SiteCostumeManagerAbilityCooldown { get; set; } = "ability under cooldown %n% default cooldown = 120 seconds";

        public string SCP999RoleName { get; set; } = "SCP-999";
        public string SCP999Description { get; set; } = "A friendly SCP that provides passive regeneration to nearby players, can pickup 20 pieces of candy, able to HEAR scps and slightly slowed movement";

        public string TheKidRoleName { get; set; } = "The Kid";
        public string TheKidDescription { get; set; } = "A short classD with a speed boost and can pick up 5 candies";

        public string JoeBidenRoleName { get; set; } = "Joe Biden";
        public string JoeBidenDescription { get; set; } = "A guard that has slowed movement but enhanced firepower";

        public string ClassDInformerRoleName { get; set; } = "ClassD Informer";
        public string ClassDInformerDescription { get; set; } = "A Class-D personnel with access to critical information";
        public string ClassDInformerAbilityDescription { get; set; } = "Receives constant updates on the status of the warhead, SCPs, and NTF remaining";
        public string Warhead { get; set; } = "Warhead";
        public string Ntf { get; set; } = "NTF";
        public string Scps { get; set; } = "SCPS";
        public string ArmedTranslation { get; set; } = "Armed";
        public string DetonatedTranslation { get; set; } = "Detonated";
        public string InProgressTranslation { get; set; } = "In Progress";
        public string NotArmedTranslation { get; set; } = "Not Armed";

        public string BusinessmanRoleName { get; set; } = "Businessman";
        public string BusinessmanDescription { get; set; } = "A savvy individual who generates 1 coin every 30 seconds";

        public string GhostRoleName { get; set; } = "Ghost";
        public string GhostDescription { get; set; } = "A Class-D with the ability to pass through doors but at the cost of slowed movement";
        public string GhostAbilityDescription { get; set; } = "Press ALT to be able to pass thorugh doors for 10 seconds with a 90 second cooldown";
        public string GhostAbilityCooldown { get; set; } = "ability under cooldown %n% default cooldown = 90 seconds";

        public string LightTechnicianRoleName { get; set; } = "Light Technician";
        public string LightTechnicianDescription { get; set; } = "A Guard with the ability to turn off lights in the room he is currently in ";
        public string LightTechnicianAbilityDescription { get; set; } = "Press ALT to be able to turn off lights in your current room with a 120 second cooldown";
        public string LightTechnicianAbilityCooldown { get; set; } = "ability under cooldown %n% default cooldown = 120 seconds";

        public string SCP1058RoleName { get; set; } = "SCP-1058";
        public string SCP1058Description { get; set; } = "A ClassD which possesses uncontrollable invisibility";
        public string SCP1058InvisibleMessage { get; set; } = "You're invisible! Remaining invisibility time: %time% seconds";

        public string TelekineticDboyRoleName { get; set; } = "Telekinetic Dboy";
        public string TelekineticDboyDescription { get; set; } = "A Dboy that can open a door at any range";
        public string TelekineticDboyAbilityDescription { get; set; } = "Look at a door button and press alt to open it aslong as you have a keycard to open the door if needed and it isnt locked";
        public string TelekineticDboyAbilityDenied { get; set; } = "Access Denied";

        public string wardenRoleName { get; set; } = "Warden";
        public string wardenDescription { get; set; } = "A Facility guard able to see through the dark and flashbangs via pressing alt";
        public string wardenAbilityDescription { get; set; } = "By pressing alt you can see through flashbangs and see through dark rooms";
        public string wardenAbilityWord { get; set; } = "Ability";
    }
}
