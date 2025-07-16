using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay.UI.Menus;

public class PauseMenu
{
    private bool _isPaused;
    private bool _prevState;

    public bool IsPaused => _isPaused;

    public void Update(GameHS game, bool allowToggle = true)
    {
        bool pressed = game.userInput.IsActionPressed("pause");
        if (allowToggle && pressed && !_prevState)
        {
            _isPaused = !_isPaused;
        }
        _prevState = pressed;

        if (_isPaused && Keyboard.GetState().IsKeyDown(Keys.X))
        {
            game.Exit();
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isPaused) return;
        spriteBatch.DrawString(game._font, "Pause", new Vector2(100, 150), Color.White);
    }
}
