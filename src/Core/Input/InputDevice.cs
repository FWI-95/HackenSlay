/// <summary>
/// Enumerates possible input devices used by the player.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: rework Input System to support multiple input devices, on the fly switching, and better abstraction
// like a inputmapping system in game engines like Unioty or Unreal Engine

namespace HackenSlay.Core.Input
{
    /// <summary>
    /// Supported device types for user input.
    /// </summary>
    public enum InputDevice
    {
        Keyboard,
        Controller
    }
}