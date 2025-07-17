using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay.UI.Elements;

public class SimpleButton
{
    private Rectangle _bounds;
    private readonly string _text;
    private readonly Action _onClick;
    private Texture2D _pixel;
    private SpriteFont _font;
    private bool _pressedPrev;

    public SimpleButton(GameHS game, Rectangle bounds, string text, Action onClick)
    {
        _bounds = bounds;
        _text = text;
        _onClick = onClick;
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        _font = game._font;
    }

    public void Update()
    {
        MouseState state = Mouse.GetState();
        bool hovered = _bounds.Contains(state.Position);
        bool pressed = hovered && state.LeftButton == ButtonState.Pressed;
        if (pressed && !_pressedPrev)
        {
            _onClick();
        }
        _pressedPrev = state.LeftButton == ButtonState.Pressed;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, _bounds, Color.DarkGray * 0.8f);
        Vector2 size = _font.MeasureString(_text);
        Vector2 pos = new Vector2(
            _bounds.Center.X - size.X / 2f,
            _bounds.Center.Y - size.Y / 2f);
        spriteBatch.DrawString(_font, _text, pos, Color.White);
    }
}
