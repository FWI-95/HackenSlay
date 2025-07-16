using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.UI.Menus;

public class PauseMenu
{
    private bool _isPaused;
    private bool _prevState;

    public void Update(GameHS game)
    {
        bool pressed = game.userInput.IsActionPressed("pause");
        if (pressed && !_prevState)
        {
            _isPaused = !_isPaused;
        }
        _prevState = pressed;
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isPaused) return;
        spriteBatch.DrawString(game._font, "Paused", new Vector2(100, 150), Color.White);
    }
}
