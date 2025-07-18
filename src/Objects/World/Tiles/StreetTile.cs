// Erstellt mit Unterstützung von OpenAI Codex
using HackenSlay.Core.Objects;

namespace HackenSlay.World.Tiles;

public class StreetTile : TextureObject
{
    public StreetTile()
    {
        IsMovable = false;
        IsIntangible = true;
    }
}
