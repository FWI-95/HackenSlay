// Erstellt mit Unterstützung von OpenAI Codex
using System.Collections.Generic;

namespace HackenSlay.World.Chunks;

/// <summary>
/// Manages chunk discovery using a breadth first search in clockwise order.
/// </summary>
public class ChunkManager
{
    private readonly Dictionary<(int x, int y), ChunkMeta> _chunks = new();
    private readonly Queue<(int x, int y)> _queue = new();
    private readonly int _maxAfS;
    private int _nextId = 1;

    private static readonly (int dx, int dy)[] NeighborsCw =
    {
        (0, -1), (1, -1), (1, 0), (1, 1),
        (0, 1), (-1, 1), (-1, 0), (-1, -1)
    };

    public ChunkManager(int maxAfS)
    {
        _maxAfS = maxAfS;
        var start = new ChunkMeta(0, 0) { Declared = true };
        _chunks[(0, 0)] = start;
        _queue.Enqueue((0, 0));
    }

    public ChunkMeta? GetChunk(int x, int y) =>
        _chunks.TryGetValue((x, y), out var meta) ? meta : null;

    public int Count => _chunks.Count;

    /// <summary>
    /// Declare new chunks up to the given maximum and return them.
    /// </summary>
    public IEnumerable<ChunkMeta> DeclareNext(int maxNewChunks)
    {
        var declared = new List<ChunkMeta>();
        while (_queue.Count > 0 && declared.Count < maxNewChunks)
        {
            var parentPos = _queue.Dequeue();
            var parent = _chunks[parentPos];

            int childAfS = parent.AfS + 1;
            if (childAfS > _maxAfS)
            {
                continue;
            }

            foreach (var (dx, dy) in NeighborsCw)
            {
                var pos = (parentPos.x + dx, parentPos.y + dy);
                if (_chunks.ContainsKey(pos))
                {
                    continue;
                }

                var meta = new ChunkMeta(_nextId++, childAfS) { Declared = true };
                _chunks[pos] = meta;
                _queue.Enqueue(pos);
                declared.Add(meta);

                if (declared.Count >= maxNewChunks)
                {
                    break;
                }
            }
        }

        return declared;
    }
}
