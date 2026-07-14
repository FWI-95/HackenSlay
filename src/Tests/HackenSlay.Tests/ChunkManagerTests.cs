// Erstellt mit Unterstützung von OpenAI Codex
using HackenSlay.World.Chunks;
using Xunit;

namespace HackenSlay.Tests;

public class ChunkManagerTests
{
    [Fact]
    public void AssignsIdsClockwiseAroundStart()
    {
        var manager = new ChunkManager(1);
        manager.DeclareNext(8);

        Assert.Equal(1, manager.GetChunk(0, -1)?.Id);
        Assert.Equal(2, manager.GetChunk(1, -1)?.Id);
        Assert.Equal(3, manager.GetChunk(1, 0)?.Id);
        Assert.Equal(4, manager.GetChunk(1, 1)?.Id);
        Assert.Equal(5, manager.GetChunk(0, 1)?.Id);
        Assert.Equal(6, manager.GetChunk(-1, 1)?.Id);
        Assert.Equal(7, manager.GetChunk(-1, 0)?.Id);
        Assert.Equal(8, manager.GetChunk(-1, -1)?.Id);
    }

    [Fact]
    public void RespectsMaxAfS()
    {
        var manager = new ChunkManager(1);
        manager.DeclareNext(100);

        Assert.Null(manager.GetChunk(0, -2));
        Assert.Equal(9, manager.Count);
    }

    [Fact]
    public void ExpandsInBfsOrder()
    {
        var manager = new ChunkManager(2);
        manager.DeclareNext(1000);

        Assert.Equal(9, manager.GetChunk(0, -2)?.Id);
        Assert.Equal(10, manager.GetChunk(1, -2)?.Id);
        Assert.Equal(24, manager.GetChunk(-2, -2)?.Id);
        Assert.Equal(2, manager.GetChunk(2, 2)?.AfS);
        Assert.Equal(25, manager.Count);
    }
}
