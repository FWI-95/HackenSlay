# Dev

This folder describes tools used during development.

## DevTool.cs

`DevTool` exposes simple factory methods to create test objects from a name string.

- `SpawnWeapon(string)` returns a `DummyWeapon` when passed "dummy". Other names trigger a debug log and return `null`.
- `SpawnItem(string)` works analogously for items and can create a `DummyItem`.
- `SpawnEnemy(string)` currently logs that other enemies are not implemented and returns a basic `Enemy` with the provided name.

## DevSpawner.cs

`DevSpawner` provides the same functionality without debug logging. It uses switch expressions to map
"dummy" to `DummyWeapon` or `DummyItem` and otherwise returns `null`. `SpawnEnemy` simply returns a new
`Enemy` instance.

## Developer Overlay

The overlay in `src/UI/Menus/DevOverlay.cs` can be toggled with the `dev_menu` input and draws a small
window for debugging.

`src/UI/Menus/DevConsole.cs` implements a simple console that opens with the `dev_console`
action (bound to the `~` key by default). Commands allow spawning objects and modifying
stats at runtime. Example commands:

```text
spawn enemy dummy
set player health 200
```

## Example

```csharp
var weapon = DevSpawner.SpawnWeapon("dummy");
// use the weapon for quick tests
```
