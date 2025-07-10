# Core

The **Core** namespace contains the fundamental building blocks of the game. It provides base types for objects that are drawn on screen, the player implementation, animation logic, debugging helpers and the input system used across other modules.

## Main classes

- **TextureObject** – base class for any drawable entity. It stores position, velocity, and a sprite texture. The class updates movement, draws the sprite and exposes an `AnimationHandler` to manage frame based animations.
- **Player** – derives from `TextureObject` and controls movement, actions and animations. Player attributes like name, health, strength and movement speed are loaded from JSON files in `data/character/*.json`.
- **Debug** – static helper for logging messages and drawing positional information when debugging is enabled.
- **Animation** – represents a sequence of frames for a specific direction and state. Used by `AnimationHandler` to update and render animated sprites.
- **Input classes** – `InputDevice`, `InputMapping` and `UserInput` read keyboard or gamepad input. Mappings are defined in JSON files under `data/input/` and actions are queried through `UserInput`.

Player JSON files configure starting stats and the animation data path. Example:

```
{
    "name": "1",
    "health": 100,
    "strength": 2,
    "walkspeed": 2,
    "runspeed": 2.5,
    "animationdata": "data/character/1_anim.json"
}
```

## Related pages

- [Items](../Items/README.md)

