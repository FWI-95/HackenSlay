// Erstellt mit Unterstützung von OpenAI Codex
using HackenSlay.Core.Objects;

namespace HackenSlay.World.Tiles;

public class EnemySpawnTile : TextureObject
{
    public EnemySpawnTile()
    {
        IsMovable = false;
        IsIntangible = true;
    }
}
