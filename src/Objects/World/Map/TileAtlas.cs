using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.World.Map;

public static class TileAtlas
{
    public static Texture2D Create(GraphicsDevice device, int tileSize)
    {
        const int cols = 3; // width of atlas in tiles
        const int rows = 2;
        var texture = new Texture2D(device, cols * tileSize, rows * tileSize);
        var data = new Color[cols * rows * tileSize * tileSize];

        void Fill(int c, int r, Color color)
        {
            for (int x = 0; x < tileSize; x++)
            {
                for (int y = 0; y < tileSize; y++)
                {
                    int index = ((r * tileSize + y) * cols * tileSize) + (c * tileSize + x);
                    data[index] = color;
                }
            }
        }

        Fill(0,0, Color.ForestGreen); // Grass / empty
        Fill(1,0, Color.LightGray);   // Street
        Fill(2,0, Color.Black);       // Obstacle
        Fill(0,1, Color.Red);         // Enemy spawn
        Fill(1,1, Color.Blue);        // Structure spawn

        texture.SetData(data);
        return texture;
    }
}
