// Erstellt mit Unterstützung von OpenAI Codex
using HackenSlay.Core.Objects;

namespace HackenSlay.World.Terrain;

public class TerrainObject : TextureObject
{
    public TerrainObject()
    {
        IsMovable = false;
        IsIntangible = false;
        _isVisible = false; // terrain objects are collision only
    }
}
