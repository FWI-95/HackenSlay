using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.World.Map;

public class TileMap
{
    private readonly TileType[,] _tiles;
    private readonly Texture2D _atlas;
    private readonly Dictionary<TileType, Rectangle> _sources;
    public int TileSize { get; }

    public TileMap(TileType[,] tiles, Texture2D atlas, int tileSize)
    {
        _tiles = tiles;
        _atlas = atlas;
        TileSize = tileSize;
        _sources = new Dictionary<TileType, Rectangle>
        {
            { TileType.Empty, new Rectangle(0,0,tileSize,tileSize) },
            { TileType.Street, new Rectangle(tileSize,0,tileSize,tileSize) },
            { TileType.Obstacle, new Rectangle(2*tileSize,0,tileSize,tileSize) },
            { TileType.EnemySpawn, new Rectangle(0,tileSize,tileSize,tileSize) },
            { TileType.StructureSpawn, new Rectangle(tileSize,tileSize,tileSize,tileSize) }
        };
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int width = _tiles.GetLength(0);
        int height = _tiles.GetLength(1);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileType t = _tiles[x, y];
                Rectangle dest = new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize);
                spriteBatch.Draw(_atlas, dest, _sources[t], Color.White);
            }
        }
    }
}
