# OBSBridge
Allows interaction with OBS within Unity games.

## MelonLoader
| Release | IL2CPP | Mono |
| ------- | ------ |----|
| ML 0.5  | ✖️ | ✖️ |
| ML 0.6  | ✅ | ✅  |
| ML 0.7  | ✅ | ✅  |

## BepInEx
| Release | IL2CPP | Mono |
|---------|----|---|
| BIE 5.X | ✖️ | ✖️ |
| BIE 6.X | ✖️ | ✖️ |

I had plans to support BIE 5.X, but BepInEx refuses to properly load any assemblies that aren't BepInEx plugins.
I really don't feel like rewriting obs-websocket-sharp and it's 6 dependencies to be BepInEx plugins.

Maybe later, but for now I'm sticking to an actually good modloader.

## [Documentation](https://github.com/WeatherElectric/OBSBridge/wiki)