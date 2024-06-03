using Exiled.API.Interfaces;

namespace InterestingSubClasses
{
    public class Translations : ITranslation
    {
        public string SiteCostumeManagerRoleName { get; set; } = "Site Costume Manager";
        public string SiteCostumeManagerDescription { get; set; } = "Can disguise all people in the same room as him as scientists for a minute.";
        public string SiteCostumeManagerAbilityDescription { get; set; } = "Press ALT to disguise everyone in the room you're in as a scientist";

        public string SCP999RoleName { get; set; } = "SCP-999";
        public string SCP999Description { get; set; } = "A friendly SCP that provides passive regeneration to nearby players, can pickup 20 pieces of candy, able to HEAR scps and slightly slowed movement.";

        public string TheKidRoleName { get; set; } = "The Kid";
        public string TheKidDescription { get; set; } = "A short classD with more stamina and can pick up 5 candies.";

        public string JoeBidenRoleName { get; set; } = "Joe Biden";
        public string JoeBidenDescription { get; set; } = "A guard that has slowed movement but enhanced firepower.";

        public string ClassDInformerRoleName { get; set; } = "ClassD Informer";
        public string ClassDInformerDescription { get; set; } = "A Class-D personnel with access to critical information.";
        public string ClassDInformerAbilityDescription { get; set; } = "Receives constant updates on the status of the warhead, SCPs, and NTF remaining.";

        public string BusinessmanRoleName { get; set; } = "Businessman";
        public string BusinessmanDescription { get; set; } = "A savvy individual who generates 1 coin every 30 seconds.";
    }
}
