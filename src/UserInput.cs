using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay;

public class UserInput
{
    Game _game;
    public UserInput(Game game)
    {
        _game = game;
    }

    public bool Down()
    {
        return
            GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Down)
            || Keyboard.GetState().IsKeyDown(Keys.S);
    }
    public bool Up()
    {
        return
            GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Up)
            || Keyboard.GetState().IsKeyDown(Keys.W);
    }
    public bool Left()
    {
        return
            GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Left)
            || Keyboard.GetState().IsKeyDown(Keys.A);
    }
    public bool Right()
    {
        return
            GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Right)
            || Keyboard.GetState().IsKeyDown(Keys.D);
    }
    public bool Shift()
    {
        return
            GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.RightShift)
            || Keyboard.GetState().IsKeyDown(Keys.LeftShift);
    }

    internal bool Escape()
    {
        return
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
            || Keyboard.GetState().IsKeyDown(Keys.Escape);
    }
}