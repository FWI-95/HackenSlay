using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using HackenSlay.Core.Objects;
using HackenSlay.World.Terrain;
using HackenSlay.World.Tiles;
using HackenSlay.World.Structures;

namespace HackenSlay.World.Map;

public static class WorldBuilder
{
    public static TileMap Build(GraphicsDevice device, MapGenerator generator)
    {
        var atlas = TileAtlas.Create(device, generator.TileSize);
        return new TileMap(generator.Tiles, atlas, generator.TileSize);
    }

    public static List<TextureObject> BuildObjects(MapGenerator generator)
    {
        var objects = new List<TextureObject>();
        for (int x = 0; x < generator.Width; x++)
        {
            for (int y = 0; y < generator.Height; y++)
            {
                TileType type = generator.Tiles[x, y];
                if (type == TileType.Empty || type == TileType.Street)
                    continue;

                Vector2 pos = new Vector2(x * generator.TileSize, y * generator.TileSize);
                switch (type)
                {
                    case TileType.Obstacle:
                        var obstacle = new Obstacle();
                        obstacle._pos = pos;
                        obstacle.Size = new Vector2(generator.TileSize, generator.TileSize);
                        objects.Add(obstacle);
                        break;
                    case TileType.EnemySpawn:
                        var spawn = new EnemySpawnTile();
                        spawn._pos = pos;
                        spawn.Size = new Vector2(generator.TileSize, generator.TileSize);
                        objects.Add(spawn);
                        break;
                    case TileType.StructureSpawn:
                        var block = new SpawnBlock("default");
                        block._pos = pos;
                        block.Size = new Vector2(generator.TileSize, generator.TileSize);
                        objects.Add(block);
                        break;
                }
            }
        }
        return objects;
    }
}
