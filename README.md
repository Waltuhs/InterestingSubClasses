# InterestingSubClasses
![downloads](https://img.shields.io/github/downloads/Waltuhs/InterestingSubClasses/total?logo=github&style=for-the-badge)
![ver](https://img.shields.io/github/v/release/Waltuhs/InterestingSubClasses?include_prereleases&logo=github&style=for-the-badge)
[![disc](https://img.shields.io/discord/1235681501849321482?label=Discord&logo=discord&style=for-the-badge)](https://discord.gg/MQAcPFJRkR)

ISC is a SCP: SL exiled plugin that addes various silly SubClasses to the game without needing Exiled.CustomRoles

### SubClasses
| |  |
| --- | --- |
| Business man | a scientist that spawns in gr-18 that generates 1 coin every 30 seconds |
| Ghost | A Class-D with the ability to pass through doors for 20 seconds with a 90 second cooldown but also at the cost of slowed movement |
| ClassD informer | A classd who gets updates via a hint OR broadcast (config) of the warhead status, Foundation forces and scps that remain alive |
| JoeBiden | A guard that has slowed movement but enhanced firepower (yes him spawning in front of stairs was a intended feature) |
| Kid | A short classD with more stamina and can pick up 5 candies |
| Light Technician | A Guard with the ability to turn off lights in the room he is currently in for 20 seconds with a 120 second cooldown |
| SCP-999 | A friendly SCP that provides passive regeneration to nearby players, can pickup 20 pieces of candy, able to HEAR scps and slightly slowed movement |
| Site Costume Manager | A scientist that can disguise all people in the same room as him as scientists for a minute by pressing ALT (has a 2 minute cooldown) |

### SubClass picking system
by default there is a 50 percent chance and 1 max player able to be picked to be a subclass at the start of a round. (all adjustable in config)

### Config
```yml
ISC:
# is the plugin enabled?
  is_enabled: true
  # is Debug mode enabled?
  debug: true
  # Minimum number of players required for subclasses to be enabled
  min_players_for_subclasses: 0
  # Enable or disable SCP-999 role
  s_c_p999_role_enabled: true
  # The spawn chance for SCP-999 role (0.0 to 1.0) (0.50 = 50%)
  s_c_p999_spawn_chance: 0.5
  # The maximum number of players that can be assigned the SCP-999 role
  s_c_p999_max_count: 1
  # Enable or disable Kid role
  kid_role_enabled: false
  # The spawn chance for Kid role (0.0 to 1.0) (0.50 = 50%)
  kid_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Kid role
  kid_max_count: 1
  # Enable or disable Site Costume Manager role
  site_costume_manager_role_enabled: false
  # The spawn chance for Site Costume Manager role (0.0 to 1.0) (0.50 = 50%)
  site_costume_manager_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Site Costume Manager role
  site_costume_manager_max_count: 1
  # Enable or disable Joe Biden role
  joe_biden_role_enabled: false
  # The spawn chance for Joe Biden role (0.0 to 1.0) (0.50 = 50%)
  joe_biden_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Joe Biden role
  joe_biden_max_count: 1
  # Enable or disable Businessman role
  businessman_role_enabled: false
  # The spawn chance for Businessman role (0.0 to 1.0) (0.50 = 50%)
  businessman_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Businessman role
  businessman_max_count: 1
  # Enable or disable Informer role
  informer_role_enabled: false
  # The spawn chance for Informer role (0.0 to 1.0) (0.50 = 50%)
  informer_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Informer role
  informer_max_count: 1
  # Enable or disable Ghost role
  ghost_role_enabled: true
  # The spawn chance for Ghost role (0.0 to 1.0) (0.50 = 50%)
  ghost_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Ghost role
  ghost_max_count: 1
  # Enable or disable Light Technician role
  light_technician_role_enabled: true
  # The spawn chance for Light Technician role (0.0 to 1.0) (0.50 = 50%)
  light_technician_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Light Technician role
  light_technician_max_count: 1
  # Should hints be broadcasts instead?
  broadcasts: false
  # Kid size
  kid_size:
    x: 1.1
    y: 0.8
    z: 1.1
  # SCP-999 size
  size999:
    x: 1.1
    y: 0.9
    z: 1.3
```

### Translations
```yml
ISC:
  site_costume_manager_role_name: 'Site Costume Manager'
  site_costume_manager_description: 'Can disguise all people in the same room as him as scientists for a minute'
  site_costume_manager_ability_description: 'Press ALT to disguise everyone in the room you''re in as a scientist'
  site_costume_manager_ability_cooldown: 'ability under cooldown %n% default cooldown = 120 seconds'
  s_c_p999_role_name: 'SCP-999'
  s_c_p999_description: 'A friendly SCP that provides passive regeneration to nearby players, can pickup 20 pieces of candy, able to HEAR scps and slightly slowed movement'
  the_kid_role_name: 'The Kid'
  the_kid_description: 'A short classD with a speed boost and can pick up 5 candies'
  joe_biden_role_name: 'Joe Biden'
  joe_biden_description: 'A guard that has slowed movement but enhanced firepower'
  class_d_informer_role_name: 'ClassD Informer'
  class_d_informer_description: 'A Class-D personnel with access to critical information'
  class_d_informer_ability_description: 'Receives constant updates on the status of the warhead, SCPs, and NTF remaining'
  businessman_role_name: 'Businessman'
  businessman_description: 'A savvy individual who generates 1 coin every 30 seconds'
  ghost_role_name: 'Ghost'
  ghost_description: 'A Class-D with the ability to pass thorugh doors but at the cost of slowed movement'
  ghost_ability_description: 'Press ALT to be able to pass thorugh doors for 10 seconds with a 90 second cooldown'
  ghost_ability_cooldown: 'ability under cooldown %n% default cooldown = 90 seconds'
  light_technician_role_name: 'Light Technician'
  light_technician_description: 'A Guard with the ability to turn off lights in the next 5 or less rooms'
  light_technician_ability_description: 'Press ALT to be able to turn off lights in your current room with a 200 second cooldown'
  light_technician_ability_cooldown: 'ability under cooldown %n% default cooldown = 120 seconds'
```

### SetSubClass command
### prefix = SSC
### description = Sets the command sender to a specified subclass

### suggestions
please either open a issue with the suggestions tag on github OR slide me a dm on discord with your suggestion for this plugin @walter.jr.
