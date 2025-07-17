using Microsoft.Xna.Framework;
using HackenSlay;
using HackenSlay.World.Map;
using HackenSlay.World.Navigation;
using Xunit;

namespace HackenSlay.Tests;

public class EnemyAiTests
{
    private static TileType[,] CreateSimpleMap()
    {
        var tiles = new TileType[3,3];
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                tiles[x, y] = TileType.Empty;
        return tiles;
    }

    [Fact]
    public void PathfinderAvoidsObstacles()
    {
        var tiles = CreateSimpleMap();
        tiles[1,0] = TileType.Obstacle;
        var path = Pathfinder.FindPath(tiles, new Point(0,0), new Point(2,0));
        Assert.NotEmpty(path);
        Assert.DoesNotContain(new Point(1,0), path);
    }

    [Fact]
    public void EnemyCalculatesVelocityTowardsPlayer()
    {
        var tiles = CreateSimpleMap();
        var enemy = new Enemy("test");
        enemy._pos = Vector2.Zero;
        Vector2 vel = enemy.CalculateVelocity(tiles, 1, new Vector2(2,0));
        Assert.Equal(new Vector2(1,0), vel);
    }
}
