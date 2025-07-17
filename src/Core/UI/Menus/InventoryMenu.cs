using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay.UI.Menus;

public class InventoryMenu
{
    private bool _isVisible;
    private bool _togglePrev;
    private Texture2D? _pixel;
    private Rectangle _bounds;
    private int _selectedIndex;

    public void LoadContent(GameHS game)
    {
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        int width = 300;
        int height = 300;
        _bounds = new Rectangle(
            game.Window.ClientBounds.Width / 2 - width / 2,
            game.Window.ClientBounds.Height / 2 - height / 2,
            width,
            height);
    }

    public void Update(GameHS game)
    {
        bool pressed = game.userInput.IsActionPressed("open_inventory");
        if (pressed && !_togglePrev)
        {
            _isVisible = !_isVisible;
        }
        _togglePrev = pressed;

        if (!_isVisible) return;

        var items = game.player.Inventory.Items;
        if (items.Count == 0) return;

        KeyboardState ks = Keyboard.GetState();
        if (ks.IsKeyDown(Keys.Down))
        {
            _selectedIndex = Math.Min(_selectedIndex + 1, items.Count - 1);
        }
        if (ks.IsKeyDown(Keys.Up))
        {
            _selectedIndex = Math.Max(_selectedIndex - 1, 0);
        }

        MouseState ms = Mouse.GetState();
        if (ms.LeftButton == ButtonState.Pressed)
        {
            int y = _bounds.Y + 20;
            for (int i = 0; i < items.Count; i++)
            {
                Rectangle itemRect = new Rectangle(_bounds.X + 20, y - 4, _bounds.Width - 40, 20);
                if (itemRect.Contains(ms.Position))
                {
                    _selectedIndex = i;
                    break;
                }
                y += 20;
            }
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible || _pixel == null) return;
        spriteBatch.Draw(_pixel, _bounds, Color.Black * 0.8f);

        var items = game.player.Inventory.Items;
        int y = _bounds.Y + 20;
        for (int i = 0; i < items.Count; i++)
        {
            Color color = i == _selectedIndex ? Color.Yellow : Color.White;
            spriteBatch.DrawString(game._font, items[i]._name, new Vector2(_bounds.X + 20, y), color);
            y += 20;
        }
    }

    public bool IsVisible => _isVisible;
}
