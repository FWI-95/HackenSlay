using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay
{
    public class InputMapping
    {
        public static readonly Dictionary<string, List<Keys>> KeyboardMapping = new()
        {
            { "walk_left", new List<Keys> { Keys.A, Keys.Left } },
            { "walk_right", new List<Keys> { Keys.D, Keys.Right } },
            { "walk_up", new List<Keys> { Keys.W, Keys.Up } },
            { "walk_down", new List<Keys> { Keys.S, Keys.Down } },
            { "sprint", new List<Keys> { Keys.LeftShift, Keys.RightShift } },
            { "pause", new List<Keys> { Keys.Escape } }
        };

        public static readonly Dictionary<string, List<Buttons>> GamePadMapping = new()
        {
            { "walk_left", new List<Buttons> { Buttons.DPadLeft, Buttons.LeftThumbstickLeft } },
            { "walk_right", new List<Buttons> { Buttons.DPadRight, Buttons.LeftThumbstickRight } },
            { "walk_up", new List<Buttons> { Buttons.DPadUp, Buttons.LeftThumbstickUp } },
            { "walk_down", new List<Buttons> { Buttons.DPadDown, Buttons.LeftThumbstickDown } },
            { "sprint", new List<Buttons> { Buttons.RightShoulder } },
            { "pause", new List<Buttons> { Buttons.Back } }
        };
    }
}
