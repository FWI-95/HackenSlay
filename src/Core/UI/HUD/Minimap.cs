// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.World.Map;

namespace HackenSlay.UI.HUD;

public class Minimap
{
    private Texture2D? _mapTexture;
    private Rectangle _bounds;

    public Minimap()
    {
    }

    public void LoadContent(GameHS game, MapGenerator generator)
    {
        _bounds = Rectangle.Empty;
    }

    public void LoadContent(GameHS game, MapGenerator generator)
    {
        int size = 150;
        _bounds = new Rectangle(
            game.GraphicsDevice.PresentationParameters.BackBufferWidth - size - 10,
            10,
            size,
            size);

        _mapTexture = generator.CreateMinimapTexture(game.GraphicsDevice);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_mapTexture != null)
        {
            spriteBatch.Draw(_mapTexture, _bounds, Color.White);
        }
    }
}
