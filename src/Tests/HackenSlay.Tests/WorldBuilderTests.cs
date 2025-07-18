using System.Linq;
using HackenSlay.World.Map;
using HackenSlay.World.Terrain;
using HackenSlay.World.Structures;
using Xunit;

namespace HackenSlay.Tests;

public class WorldBuilderTests
{
    [Fact]
    public void BuildObjectsCreatesTangibleObstaclesAndStructureSpawns()
    {
        var gen = new MapGenerator(null, 50, 50, 1, seed: 42);
        var objects = WorldBuilder.BuildObjects(gen);
        Assert.Contains(objects.OfType<Obstacle>(), o => !o.IsIntangible);
        Assert.Contains(objects.OfType<SpawnBlock>(), s => !s.IsIntangible);
    }
}

