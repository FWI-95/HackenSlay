
    using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay
{
    public class UserInput
    {
        private Game _game;

        public UserInput(Game game)
        {
            _game = game;
        }

        public bool IsActionPressed(string action)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            // Prüfen, ob eine der zugeordneten Tasten gedrückt ist
            if (InputMapping.KeyboardMapping.ContainsKey(action))
            {
                foreach (var key in InputMapping.KeyboardMapping[action])
                {
                    if (keyboardState.IsKeyDown(key))
                    {
                        return true;
                    }
                }
            }

            // Prüfen, ob einer der zugeordneten GamePad-Buttons gedrückt ist
            if (InputMapping.GamePadMapping.ContainsKey(action))
            {
                foreach (var button in InputMapping.GamePadMapping[action])
                {
                    if (gamePadState.IsButtonDown(button))
                    {
                        return true;
                    }
                }
            }

            return false;
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