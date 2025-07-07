
using System.Collections.Generic;
using HackenSlay.Core.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay
{
    public class UserInput
    {
        private Game _game;
        private InputMapping _inputMapping;
        private InputDevice _inputDevice = InputDevice.Keyboard; // Default to keyboard


        public UserInput(Game game)
        {
            _game = game;
            _inputMapping = new InputMapping();
        }

        public void Initialize()
        {
            _inputMapping.Initialize();
        }

        public void ReloadMappings()
        {
            _inputMapping.Initialize();
        }

        public bool IsActionPressed(string action)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (action == "pause")
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    return true;
                }
            }

            if (action == "pause") { Debug.Log($" containskey: {_inputMapping.KeyboardMapping.ContainsKey(action)}", DebugLevel.HIGH, DebugCategory.USERINPUT); }
            ;
            // Prüfen, ob eine der zugeordneten Tasten gedrückt ist
            if (_inputMapping.KeyboardMapping.ContainsKey(action))
            {
                foreach (var key in _inputMapping.KeyboardMapping[action])
                {
                    if (action == "pause") { Debug.Log($" key: {key}, IsKeyDown: {keyboardState.IsKeyDown(key)}", DebugLevel.HIGH, DebugCategory.USERINPUT); }
                    ;
                    if (keyboardState.IsKeyDown(key))
                    {
                        return true;
                    }
                }
            }

            // Prüfen, ob einer der zugeordneten GamePad-Buttons gedrückt ist
            if (_inputMapping.GamePadMapping.ContainsKey(action))
            {
                foreach (var button in _inputMapping.GamePadMapping[action])
                {
                    if (gamePadState.IsButtonDown(button))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Vector2 GetTargetVector()
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            Vector2 targetVector = new Vector2(gamePadState.ThumbSticks.Right.X, gamePadState.ThumbSticks.Right.Y);

            // Wenn der Thumbstick nicht bewegt wird, dann gib (0,0) zurück
            if (targetVector.LengthSquared() < 0.01f)
            {
                return Vector2.Zero;
            }

            // Normalisieren des Vektors
            targetVector.Normalize();
            return targetVector;
        }
        public Vector2 GetMousePosition()
        {
            MouseState mouseState = Mouse.GetState();
            return new Vector2(mouseState.X, mouseState.Y);
        }
    }
}

// using System;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Input;

// namespace HackenSlay;

// public class UserInput
// {
//     Game _game;
//     public UserInput(Game game)
//     {
//         _game = game;
//     }

// public bool Down()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed
//         || Keyboard.GetState().IsKeyDown(Keys.Down)
//         || Keyboard.GetState().IsKeyDown(Keys.S);
// }
// public bool Up()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed
//         || Keyboard.GetState().IsKeyDown(Keys.Up)
//         || Keyboard.GetState().IsKeyDown(Keys.W);
// }
// public bool Left()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
//         || Keyboard.GetState().IsKeyDown(Keys.Left)
//         || Keyboard.GetState().IsKeyDown(Keys.A);
// }
// public bool Right()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed
//         || Keyboard.GetState().IsKeyDown(Keys.Right)
//         || Keyboard.GetState().IsKeyDown(Keys.D);
// }
// public bool Shift()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed
//         || Keyboard.GetState().IsKeyDown(Keys.RightShift)
//         || Keyboard.GetState().IsKeyDown(Keys.LeftShift);
// }

// public bool Escape()
// {
//     return
//         GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
//         || Keyboard.GetState().IsKeyDown(Keys.Escape);
// }

//     public Vector2 GetTargetVector()
//     {
//         if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0
//         || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0)
//         {

//         }
//         else
//         {

//         }


//         return new Vector2(0,0);
//     }
// }