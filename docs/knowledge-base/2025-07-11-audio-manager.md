# Basic Audio Manager

A conversation required adding a rudimentary audio system similar to the existing
`AnimationHandler`. Each `TextureObject` now owns an `AudioManager` used to play
sound effects or music. The new system loads songs for menus and effects for
player actions and enemy death.

Key changes:
- `AudioManager` now supports loading and playing `SoundEffect` and `Song`.
- `TextureObject` instantiates an `AudioManager` by default.
- `Player` plays an attack sound when using a weapon.
- `Enemy` plays a death sound when its health reaches zero.
- `StartMenu` and `PauseMenu` load background music that plays while active.

Paths for the audio files are placeholders like `audio/attack` or `audio/start_menu`.
Actual assets can be added later through the MonoGame content pipeline.
