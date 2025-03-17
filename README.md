# InterestingSubClasses
![downloads](https://img.shields.io/github/downloads/Waltuhs/InterestingSubClasses/total?logo=github&style=for-the-badge)
![ver](https://img.shields.io/github/v/release/Waltuhs/InterestingSubClasses?include_prereleases&logo=github&style=for-the-badge)

if u have any issues dm walter.jr. on discord and say it yk

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
| SCP-1058 | A ClassD which possesses uncontrollable invisibility |
| SCP-999 | A friendly SCP that provides passive regeneration to nearby players, can pickup 20 pieces of candy, able to HEAR scps and slightly slowed movement |
| Site Costume Manager | A scientist that can disguise all people in the same room as him as scientists for a minute by pressing ALT (has a 2 minute cooldown) |
| Telekinetic Dboy | A ClassD that can Look at a door button and press alt to open it aslong as you have a keycard to open the door if needed and it isnt locked |
| Warden | A Facility guard able to disable the flashbanged effect via pressing alt with a 10 second cooldown and 5 second duration (kinda stupid)| 

### READ BEFORE A BUG REPORT!!!
A) the ALT "keybind" for abilities is actually just your no clip key but is alt by default and not many people change that so theres no point in adding confusion with labeling it the "no clip key"
B) The command SSC (SetSubClass) will only work if you werent a subclass before using it (you can also die as a subclass then use the command perfectly fine)

### SubClass picking system
Each SubClass by default has a 50% chance of spawning and The maximum number of players that can be assigned it on round start is 1 (all adjustable in config)

### Config
```yml
ISC:
# is the plugin enabled?
  is_enabled: true
  # is Debug mode enabled?
  debug: false
  # Minimum number of players required for subclasses to be enabled
  min_players_for_subclasses: 5
  # Enable or disable SCP-999 role
  s_c_p999_role_enabled: true
  # The spawn chance for SCP-999 role (0.0 to 1.0) (0.50 = 50%)
  s_c_p999_spawn_chance: 0.5
  # The maximum number of players that can be assigned the SCP-999 role
  s_c_p999_max_count: 1
  # SCP-999 spawn room
  s_c_p999_room: LczCafe
  # Whether the xyz spawn overrides the room spawn
  s_c_p999_x_y_z_enabled: false
  # XYZ to spawn SCP-999 at if its enabled
  s_c_p999_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Kid role
  kid_role_enabled: true
  # The spawn chance for Kid role (0.0 to 1.0) (0.50 = 50%)
  kid_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Kid role
  kid_max_count: 1
  # Kid spawn room
  kid_room: LczToilets
  # Whether the xyz spawn overrides the room spawn
  kid_x_y_z_enabled: false
  # XYZ to spawn Kid at if its enabled
  kid_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Site Costume Manager role
  site_costume_manager_role_enabled: true
  # The spawn chance for Site Costume Manager role (0.0 to 1.0) (0.50 = 50%)
  site_costume_manager_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Site Costume Manager role
  site_costume_manager_max_count: 1
  # Costume spawn room
  costume_room: Lcz914
  # Whether the xyz spawn overrides the room spawn
  costume_x_y_z_enabled: false
  # XYZ to spawn Costume at if its enabled
  costume_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Joe Biden role
  joe_biden_role_enabled: true
  # The spawn chance for Joe Biden role (0.0 to 1.0) (0.50 = 50%)
  joe_biden_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Joe Biden role
  joe_biden_max_count: 1
  # Joe spawn room
  joe_room: EzGateB
  # Whether the xyz spawn overrides the room spawn
  joe_x_y_z_enabled: true
  # XYZ to spawn Joe at if its enabled
  joe_x_y_z:
    x: 21.445
    y: 991.882
    z: -35.211
  # Enable or disable Businessman role
  businessman_role_enabled: true
  # The spawn chance for Businessman role (0.0 to 1.0) (0.50 = 50%)
  businessman_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Businessman role
  businessman_max_count: 1
  # Businessman spawn room
  bus_room: LczGlassBox
  # Whether the xyz spawn overrides the room spawn
  bus_x_y_z_enabled: false
  # XYZ to spawn Businessman at if its enabled
  bus_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Informer role
  informer_role_enabled: true
  # The spawn chance for Informer role (0.0 to 1.0) (0.50 = 50%)
  informer_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Informer role
  informer_max_count: 1
  # Informer spawn room
  informer_room: LczClassDSpawn
  # Whether the xyz spawn overrides the room spawn
  informer_x_y_z_enabled: false
  # XYZ to spawn Informer at if its enabled
  informer_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Ghost role
  ghost_role_enabled: true
  # The spawn chance for Ghost role (0.0 to 1.0) (0.50 = 50%)
  ghost_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Ghost role
  ghost_max_count: 1
  # Ghost spawn room
  ghost_room: LczClassDSpawn
  # Whether the xyz spawn overrides the room spawn
  ghost_x_y_z_enabled: false
  # XYZ to spawn Ghost at if its enabled
  ghost_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable Light Technician role
  light_technician_role_enabled: true
  # The spawn chance for Light Technician role (0.0 to 1.0) (0.50 = 50%)
  light_technician_spawn_chance: 0.5
  # The maximum number of players that can be assigned the Light Technician role
  light_technician_max_count: 1
  # LightTech spawn room
  light_tech_room: EzCafeteria
  # Whether the xyz spawn overrides the room spawn
  light_tech_x_y_z_enabled: false
  # XYZ to spawn LightTech at if its enabled
  light_tech_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable SCP1058 role
  s_c_p1058_role_enabled: true
  # The spawn chance for SCP1058 role (0.0 to 1.0) (0.50 = 50%)
  s_c_p1058_spawn_chance: 0.5
  # The maximum number of players that can be assigned the SCP1058 role
  s_c_p1058_max_count: 1
  # SCP1058 spawn room
  s_c_p1058_room: LczClassDSpawn
  # Whether the xyz spawn overrides the room spawn
  s_c_p1058_x_y_z_enabled: false
  # XYZ to spawn SCP1058 at if its enabled
  s_c_p1058_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable TelekineticDboy role
  telekinetic_dboy_role_enabled: true
  # The spawn chance for TelekineticDboy role (0.0 to 1.0) (0.50 = 50%)
  telekinetic_dboy_spawn_chance: 0.5
  # The maximum number of players that can be assigned the TelekineticDboy role
  telekinetic_dboy_max_count: 1
  # TelekineticDboy spawn room
  telekinetic_dboy_room: LczClassDSpawn
  # Whether the xyz spawn overrides the room spawn
  telekinetic_dboy_x_y_z_enabled: false
  # XYZ to spawn warden at if its enabled
  telekinetic_dboy_x_y_z:
    x: 9
    y: 9
    z: 9
  # Enable or disable warden role
  warden_role_enabled: true
  # The spawn chance for warden role (0.0 to 1.0) (0.50 = 50%)
  warden_spawn_chance: 0.5
  # The maximum number of players that can be assigned the warden role
  warden_max_count: 1
  # warden spawn room
  warden_room: LczArmory
  # Whether the xyz spawn overrides the room spawn
  warden_x_y_z_enabled: false
  # XYZ to spawn warden at if its enabled
  warden_x_y_z:
    x: 9
    y: 9
    z: 9
  # Should hints be broadcasts instead?
  broadcasts: false
  # Kid size
  kid_size:
    x: 1.1
    y: 0.8
    z: 1.1
  # SCP-999 size
  size999:
    x: 1
    y: 1
    z: 1
```

### Translations
```yml
ISC:
  sub_class_spawn_hint: 'You''ve been set to'
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
  warhead: 'Warhead'
  ntf: 'NTF'
  scps: 'SCPS'
  armed_translation: 'Armed'
  detonated_translation: 'Detonated'
  in_progress_translation: 'In Progress'
  not_armed_translation: 'Not Armed'
  businessman_role_name: 'Businessman'
  businessman_description: 'A savvy individual who generates 1 coin every 30 seconds'
  ghost_role_name: 'Ghost'
  ghost_description: 'A Class-D with the ability to pass through doors but at the cost of slowed movement'
  ghost_ability_description: 'Press ALT to be able to pass thorugh doors for 10 seconds with a 90 second cooldown'
  ghost_ability_cooldown: 'ability under cooldown %n% default cooldown = 90 seconds'
  light_technician_role_name: 'Light Technician'
  light_technician_description: 'A Guard with the ability to turn off lights in the room he is currently in '
  light_technician_ability_description: 'Press ALT to be able to turn off lights in your current room with a 120 second cooldown'
  light_technician_ability_cooldown: 'ability under cooldown %n% default cooldown = 120 seconds'
  s_c_p1058_role_name: 'SCP-1058'
  s_c_p1058_description: 'A ClassD which possesses uncontrollable invisibility'
  s_c_p1058_invisible_message: 'You''re invisible! Remaining invisibility time: %time% seconds'
  telekinetic_dboy_role_name: 'Telekinetic Dboy'
  telekinetic_dboy_description: 'A Dboy that can open a door at any range'
  telekinetic_dboy_ability_description: 'Look at a door button and press alt to open it aslong as you have a keycard to open the door if needed and it isnt locked'
  telekinetic_dboy_ability_denied: 'Access Denied'
  warden_role_name: 'Warden'
  warden_description: 'A Facility guard able to disable the flashbanged effect via pressing alt'
  warden_ability_description: 'By pressing alt you can disable the flashbang effect'
  warden_ability_word: 'Ability'
  warden_ability_regening: 'The ability cant be used while regenerating'
```

### SetSubClass command
### prefix = SSC
### description = Sets the command sender to a specified subclass

### suggestions
please either open a issue with the suggestions tag on github OR slide me a dm on discord with your suggestion for this plugin @walter.jr.
