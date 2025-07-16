using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable enable

namespace HackenSlay.World.Map;

public class MapGenerator
{
    public TileType[,] Tiles { get; private set; }
    public int Width { get; }
    public int Height { get; }
    public int TileSize { get; }
    public BiomeType Biome { get; }

    private readonly Random _random;
    private readonly Texture2D? _pixel;

    public MapGenerator(GraphicsDevice? graphicsDevice, int width, int height, int tileSize = 64, int? seed = null, BiomeType biome = BiomeType.Plains)
    {
        Width = width;
        Height = height;
        TileSize = tileSize;
        Biome = biome;
        _random = seed.HasValue ? new Random(seed.Value) : new Random();
        if (graphicsDevice != null)
        {
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }
        Tiles = new TileType[Width, Height];
        Generate();
    }

    private void Generate()
    {
        // Start with all tiles empty
        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                Tiles[x, y] = TileType.Empty;

        GenerateStreets();
        PlaceObstacles();
        PlaceEnemySpawns();
        PlaceStructureSpawns();
    }

    private void GenerateStreets()
    {
        int x = Width / 2;
        int y = Height / 2;
        int steps = Width * Height;
        Tiles[x, y] = TileType.Street;

        for (int i = 0; i < steps; i++)
        {
            int dir = _random.Next(4);
            switch (dir)
            {
                case 0: x++; break;
                case 1: x--; break;
                case 2: y++; break;
                case 3: y--; break;
            }
            x = Math.Clamp(x, 0, Width - 1);
            y = Math.Clamp(y, 0, Height - 1);
            Tiles[x, y] = TileType.Street;
        }
    }

    private void PlaceObstacles()
    {
        double obstacleChance = _random.Next(10, 21) / 100.0; // between 10% and 20%
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (Tiles[x, y] == TileType.Empty && _random.NextDouble() < obstacleChance)
                {
                    Tiles[x, y] = TileType.Obstacle;
                }
            }
        }
    }

    private void PlaceEnemySpawns()
    {
        int spawnsLeft = Math.Max(1, (Width + Height) / 20);
        int attempts = 0;
        while (spawnsLeft > 0 && attempts < 1000)
        {
            int x = _random.Next(Width);
            int y = _random.Next(Height);
            bool onEdge = x == 0 || x == Width - 1 || y == 0 || y == Height - 1;
            if (onEdge && Tiles[x, y] == TileType.Empty)
            {
                Tiles[x, y] = TileType.EnemySpawn;
                spawnsLeft--;
            }
            attempts++;
        }
    }

    private void PlaceStructureSpawns()
    {
        int structures = Math.Max(1, (Width + Height) / 30);
        for (int i = 0; i < structures; i++)
        {
            int x = _random.Next(Width);
            int y = _random.Next(Height);
            if (Tiles[x, y] == TileType.Empty)
                Tiles[x, y] = TileType.StructureSpawn;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Color color = Color.Transparent;
                switch (Tiles[x, y])
                {
                    case TileType.Street:
                        color = Color.Gray;
                        break;
                    case TileType.Obstacle:
                        color = Color.DarkGray;
                        break;
                    case TileType.EnemySpawn:
                        color = Color.Red;
                        break;
                    case TileType.StructureSpawn:
                        color = Color.Green;
                        break;
                }
                if (color != Color.Transparent && _pixel != null)
                {
                    Rectangle rect = new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize);
                    spriteBatch.Draw(_pixel, rect, color);
                }
            }
        }
    }
}
