using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.World.Map;

public static class WorldBuilder
{
    public static TileMap Build(GraphicsDevice device, MapGenerator generator)
    {
        var atlas = TileAtlas.Create(device, generator.TileSize);
        return new TileMap(generator.Tiles, atlas, generator.TileSize);
    }
}
