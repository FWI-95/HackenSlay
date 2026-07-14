// Erstellt mit Unterstützung von OpenAI Codex
namespace HackenSlay.World.Chunks;

/// <summary>
/// Stores metadata about a world chunk.
/// </summary>
public class ChunkMeta
{
    public int Id { get; }
    public int AfS { get; }
    public bool Declared { get; set; }
    public bool Generated { get; set; }

    public ChunkMeta(int id, int afs)
    {
        Id = id;
        AfS = afs;
    }
}
