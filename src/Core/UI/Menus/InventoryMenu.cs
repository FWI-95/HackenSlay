using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HackenSlay;

namespace HackenSlay.UI.Menus;

public class InventoryMenu
{
    private bool _isVisible;
    private bool _togglePrev;
    private Texture2D? _pixel;
    private Rectangle _bounds;
    private Rectangle[] _cells = Array.Empty<Rectangle>();
    private Rectangle[] _hotbars = Array.Empty<Rectangle>();
    private Rectangle _primary;
    private Rectangle _secondary;
    private bool _dragging;
    private int _dragIndex;
    private Item? _dragItem;
    private Vector2 _dragOffset;
    private bool _mousePrev;

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

        int cellSize = 48;
        int padding = 10;
        _cells = new Rectangle[16];
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                int x = _bounds.X + padding + c * (cellSize + padding);
                int y = _bounds.Y + padding + r * (cellSize + padding);
                _cells[r * 4 + c] = new Rectangle(x, y, cellSize, cellSize);
            }
        }

        int bottom = game.GraphicsDevice.PresentationParameters.BackBufferHeight - cellSize - padding;
        _hotbars = new Rectangle[4];
        for (int i = 0; i < 4; i++)
        {
            int x = padding + i * (cellSize + padding);
            _hotbars[i] = new Rectangle(x, bottom, cellSize, cellSize);
        }
        _primary = new Rectangle(padding, bottom - cellSize - padding, cellSize, cellSize);
        _secondary = new Rectangle(padding + cellSize + padding, bottom - cellSize - padding, cellSize, cellSize);
    }

    public void Update(GameHS game)
    {
        bool pressed = game.userInput.IsActionPressed("open_inventory");
        if (pressed && !_togglePrev)
        {
            _isVisible = !_isVisible;
        }
        _togglePrev = pressed;

        if (!_isVisible)
            return;

        var items = game.player.Inventory.Items;

        MouseState ms = Mouse.GetState();
        Vector2 mouse = new Vector2(ms.X, ms.Y);

        if (ms.LeftButton == ButtonState.Pressed && !_mousePrev)
        {
            for (int i = 0; i < items.Count && i < _cells.Length; i++)
            {
                if (_cells[i].Contains(ms.Position))
                {
                    _dragging = true;
                    _dragIndex = i;
                    _dragItem = items[i];
                    _dragOffset = mouse - new Vector2(_cells[i].X, _cells[i].Y);
                    break;
                }
            }
        }
        else if (ms.LeftButton == ButtonState.Released && _mousePrev && _dragging && _dragItem != null)
        {
            bool handled = false;
            for (int i = 0; i < _cells.Length && i < items.Count; i++)
            {
                if (_cells[i].Contains(ms.Position))
                {
                    game.player.Inventory.MoveItem(_dragIndex, i);
                    handled = true;
                    break;
                }
            }

            for (int i = 0; i < _hotbars.Length && !handled; i++)
            {
                if (_hotbars[i].Contains(ms.Position))
                {
                    game.player.Inventory.MoveItem(_dragIndex, i);
                    handled = true;
                    break;
                }
            }


            if (!handled && !_bounds.Contains(ms.Position))
            {
                game.player.DropItem(game, _dragItem);
                handled = true;
            }

            _dragging = false;
            _dragItem = null;
        }

        _mousePrev = ms.LeftButton == ButtonState.Pressed;
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible || _pixel == null)
            return;

        spriteBatch.Draw(_pixel, _bounds, Color.Black * 0.8f);

        var items = game.player.Inventory.Items;
        for (int i = 0; i < _cells.Length; i++)
        {
            spriteBatch.Draw(_pixel, _cells[i], Color.Black * 0.5f);
            if (i < items.Count && (!_dragging || i != _dragIndex))
            {
                var tex = items[i]._sprite;
                if (tex != null)
                {
                    spriteBatch.Draw(tex, Fit(tex, _cells[i]), Color.White);
                }
            }
        }

        for (int i = 0; i < _hotbars.Length; i++)
        {
            spriteBatch.Draw(_pixel, _hotbars[i], Color.Black * 0.5f);
        }
        spriteBatch.Draw(_pixel, _primary, Color.Black * 0.5f);
        spriteBatch.Draw(_pixel, _secondary, Color.Black * 0.5f);

        if (_dragging && _dragItem != null && _dragItem._sprite != null)
        {
            Vector2 pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y) - _dragOffset;
            spriteBatch.Draw(_dragItem._sprite, new Rectangle((int)pos.X, (int)pos.Y, _cells[0].Width, _cells[0].Height), Color.White);
        }
    }

    public bool IsVisible => _isVisible;

    private static Rectangle Fit(Texture2D tex, Rectangle bounds)
    {
        float scale = Math.Min((float)bounds.Width / tex.Width, (float)bounds.Height / tex.Height);
        int w = (int)(tex.Width * scale);
        int h = (int)(tex.Height * scale);
        int x = bounds.X + (bounds.Width - w) / 2;
        int y = bounds.Y + (bounds.Height - h) / 2;
        return new Rectangle(x, y, w, h);
    }
}
