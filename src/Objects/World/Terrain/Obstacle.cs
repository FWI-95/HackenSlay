// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;

namespace HackenSlay.World.Terrain;

public class Obstacle : TextureObject
{
    public Obstacle()
    {
        IsIntangible = false;
        IsMovable = false;
        _isVisible = false; // obstacles are collision only, not drawn
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
    }
}
