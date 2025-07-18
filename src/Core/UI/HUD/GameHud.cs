// Erstellt mit Unterstützung von OpenAI Codex
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.World.Map;

namespace HackenSlay.UI.HUD;

public class GameHud
{
    private Texture2D? _pixel;
    private Rectangle[] _hotbars = Array.Empty<Rectangle>();
    private Rectangle _primary;
    private Rectangle _secondary;
    private Minimap _minimap;

    public GameHud()
    {
        _minimap = new Minimap();
    }

    public void LoadContent(GameHS game, MapGenerator generator)
    {
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        int size = 48;
        int padding = 10;
        int bottom = game.GraphicsDevice.PresentationParameters.BackBufferHeight - size - padding;
        _hotbars = new Rectangle[4];
        for (int i = 0; i < 4; i++)
        {
            int x = padding + i * (size + padding);
            _hotbars[i] = new Rectangle(x, bottom, size, size);
        }
        _primary = new Rectangle(padding, bottom - size - padding, size, size);
        _secondary = new Rectangle(padding + size + padding, bottom - size - padding, size, size);

        _minimap.LoadContent(game, generator);
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        // currently no logic needed
    }

    private static Rectangle Fit(Texture2D tex, Rectangle bounds)
    {
        float scale = Math.Min((float)bounds.Width / tex.Width, (float)bounds.Height / tex.Height);
        int w = (int)(tex.Width * scale);
        int h = (int)(tex.Height * scale);
        int x = bounds.X + (bounds.Width - w) / 2;
        int y = bounds.Y + (bounds.Height - h) / 2;
        return new Rectangle(x, y, w, h);
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (_pixel == null) return;

        spriteBatch.DrawString(game._font, $"HP: {game.player._health}", new Vector2(10, 10), Color.White);

        for (int i = 0; i < _hotbars.Length; i++)
        {
            spriteBatch.Draw(_pixel, _hotbars[i], Color.Black * 0.5f);
            if (game.player.Inventory.Items.Count > i)
            {
                var item = game.player.Inventory.Items[i];
                var tex = item._sprite;
                if (tex != null)
                {
                    spriteBatch.Draw(tex, Fit(tex, _hotbars[i]), Color.White);
                }
            }
        }

        spriteBatch.Draw(_pixel, _primary, Color.Black * 0.5f);
        var primaryWeapon = game.player.CurrentWeapon;
        if (primaryWeapon?._sprite != null)
        {
            spriteBatch.Draw(primaryWeapon._sprite, Fit(primaryWeapon._sprite, _primary), Color.White);
        }

        spriteBatch.Draw(_pixel, _secondary, Color.Black * 0.5f);
        // currently using same weapon for secondary
        if (primaryWeapon?._sprite != null)
        {
            spriteBatch.Draw(primaryWeapon._sprite, Fit(primaryWeapon._sprite, _secondary), Color.White);
        }

        _minimap.Draw(spriteBatch);
    }
}
