using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.UI.Menus;

public class StartMenu
{
    private bool _active = true;

    public bool IsActive => _active;

    public void Update(GameHS game)
    {
        if (_active && game.userInput.IsActionPressed("pause"))
        {
            _active = false;
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_active) return;
        spriteBatch.DrawString(game._font, "Start Screen - Press Escape", new Vector2(100, 100), Color.White);
    }
}
