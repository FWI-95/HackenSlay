using System.Linq;
using HackenSlay.World.Map;
using Xunit;

namespace HackenSlay.Tests;

public class MapGeneratorTests
{
    [Fact]
    public void GeneratesStreetTiles()
    {
        var gen = new MapGenerator(null, 10, 10, 1, seed: 42);
        Assert.Contains(TileType.Street, gen.Tiles.Cast<TileType>());
    }

    [Fact]
    public void PlacesEnemySpawns()
    {
        var gen = new MapGenerator(null, 10, 10, 1, seed: 42);
        Assert.Contains(TileType.EnemySpawn, gen.Tiles.Cast<TileType>());
    }

    [Fact]
    public void DesertHasFewerObstaclesThanForest()
    {
        var desert = new MapGenerator(null, 20, 20, 1, seed: 42, biome: BiomeType.Desert);
        var forest = new MapGenerator(null, 20, 20, 1, seed: 42, biome: BiomeType.Forest);
        int desertObstacles = desert.Tiles.Cast<TileType>().Count(t => t == TileType.Obstacle);
        int forestObstacles = forest.Tiles.Cast<TileType>().Count(t => t == TileType.Obstacle);
        Assert.True(desertObstacles < forestObstacles);
    }
}
