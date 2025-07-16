using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

public class DevOverlay
{
    bool _isVisible;
    bool _previousToggle;
    Texture2D _pixel;
    Rectangle _rect;

    public void LoadContent(GameHS game)
    {
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        int width = game.Window.ClientBounds.Width / 4;
        int height = game.Window.ClientBounds.Height / 2;
        _rect = new Rectangle(10, 10, width, height);
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        bool pressed = game.userInput.IsActionPressed("dev_menu");
        if (pressed && !_previousToggle)
        {
            _isVisible = !_isVisible;
        }
        _previousToggle = pressed;
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible) return;
        spriteBatch.Draw(_pixel, _rect, Color.Black * 0.5f);
        spriteBatch.DrawString(game._font, "Developer Menu", new Vector2(_rect.X + 10, _rect.Y + 10), Color.White);
    }
}
