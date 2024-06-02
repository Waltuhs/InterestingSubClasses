# InterestingSubClasses
![downloads](https://img.shields.io/github/downloads/Waltuhs/InterestingSubClasses/total?logo=github&style=for-the-badge)
![ver](https://img.shields.io/github/v/release/Waltuhs/InterestingSubClasses?include_prereleases&logo=github&style=for-the-badge)
[![disc](https://img.shields.io/discord/1235681501849321482?label=Discord&logo=discord&style=for-the-badge)](https://discord.gg/MQAcPFJRkR)

ISC is a SCP: SL exiled plugin that addes various silly SubClasses to the game without needing Exiled.CustomRoles

### SubClasses
| |  |
| --- | --- |
| Business man | a scientist that spawns in gr-18 that generates 1 coin every 30 seconds |
| ClassD informer | A classd who gets updates via a hint of the warhead status, Foundation forces and scps that remain alive |
| JoeBiden | A guard that has slowed movement but enhanced firepower (yes him spawning in front of stairs was a intended feature) |
| Kid | A short d class that spawns in SCP-330 and can pick up 5 candies |
| SCP-999 | A tutorial that spawns in scp-330 also provides passive regeneration to nearby players and can pickup 20 pieces of candy |
| Site Costume Manager | A scientist that can disguise all people in the same room as him as scientists for a minute by pressing ALT (has a 120 second cooldown) |

### Config
```yml
ISC:
# is the plugin enabled?
  is_enabled: true
  # is Debug mode enabled?
  debug: false
  # The minimum number of players required to enable subclasses.
  min_players_for_subclasses: 4
  # Is the business man SubClass enabled?
  businessman_role_enabled: true
  # Is the Informer SubClass enabled?
  informer_role_enabled: true
  # Is the JoeBiden SubClass enabled?
  joe_biden_role_enabled: true
  # Is the Kid SubClass enabled?
  kid_role_enabled: true
  # Is the SCP999 SubClass enabled?
  s_c_p999_role_enabled: true
  # Is the SiteCostumeManager SubClass enabled?
  site_costume_manager_role_enabled: true
```

### SubClass picking system
A maximum of 1 person can spawn as specific subclass e.g one kid, one business man, one informer etc etc
(this is planned to be adjustable in config)

### suggestions
please either open a issue with the suggestions tag on github OR slide me a dm on discord with your suggestion for this plugin @walter.jr.