/// <summary>
/// Handles mapping of actions to keyboard and controller inputs.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties


// using System.Collections.Generic;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Input;

// namespace HackenSlay
// {
//     public class InputMapping
//     {
//         public static readonly Dictionary<string, List<Keys>> KeyboardMapping = new()
//         {
//             { "walk_left", new List<Keys> { Keys.A, Keys.Left } },
//             { "walk_right", new List<Keys> { Keys.D, Keys.Right } },
//             { "walk_up", new List<Keys> { Keys.W, Keys.Up } },
//             { "walk_down", new List<Keys> { Keys.S, Keys.Down } },
//             { "sprint", new List<Keys> { Keys.LeftShift, Keys.RightShift } },
//             { "pause", new List<Keys> { Keys.Escape } }
//         };

//         public static readonly Dictionary<string, List<Buttons>> GamePadMapping = new()
//         {
//             { "walk_left", new List<Buttons> { Buttons.DPadLeft, Buttons.LeftThumbstickLeft } },
//             { "walk_right", new List<Buttons> { Buttons.DPadRight, Buttons.LeftThumbstickRight } },
//             { "walk_up", new List<Buttons> { Buttons.DPadUp, Buttons.LeftThumbstickUp } },
//             { "walk_down", new List<Buttons> { Buttons.DPadDown, Buttons.LeftThumbstickDown } },
//             { "sprint", new List<Buttons> { Buttons.RightShoulder } },
//             { "pause", new List<Buttons> { Buttons.Back } }
//         };
//     }
// }

using System;
using System.Collections.Generic;
using HackenSlay.Core.IO;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay
{
    /// <summary>
    /// Stores configured input mappings loaded from JSON files.
    /// </summary>
    public class InputMapping
    {
        public Dictionary<string, List<Keys>> KeyboardMapping { get; private set; }
        public Dictionary<string, List<Buttons>> GamePadMapping { get; private set; }

        /// <summary>
        /// Constructs an empty input mapping.
        /// </summary>
        public InputMapping()
        {
            KeyboardMapping = new Dictionary<string, List<Keys>>();
            GamePadMapping = new Dictionary<string, List<Buttons>>();
        }

        /// <summary>
        /// Initializes mappings by reading the default configuration files.
        /// </summary>
        public void Initialize()
        {
            KeyboardMapping.Clear();
            GamePadMapping.Clear();

            LoadFromJson("data/input/keyboard.json");
            LoadFromJson("data/input/gamepad.json");
        }

        /// <summary>
        /// Loads mappings from the specified JSON file.
        /// </summary>
        public void LoadFromJson(string filePath)
        {
            try
            {
                var rawMapping = JSONHandler.Load<Dictionary<string, List<string>>>(filePath);

                if (rawMapping == null) return;

                foreach (var entry in rawMapping)
                {
                    List<Keys> keys = new();
                    List<Buttons> buttons = new();

                    foreach (var input in entry.Value)
                    {
                        if (Enum.TryParse(input, true, out Keys key)) // Prüfen, ob es ein Keyboard-Key ist
                        {
                            keys.Add(key);
                        }
                        else if (Enum.TryParse(input, true, out Buttons button)) // Prüfen, ob es ein GamePad-Button ist
                        {
                            buttons.Add(button);
                        }
                    }

                    if (keys.Count > 0)
                        KeyboardMapping[entry.Key] = keys;

                    if (buttons.Count > 0)
                        GamePadMapping[entry.Key] = buttons;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Eingabezuordnung: {ex.Message}");
            }
        }
    }
}
