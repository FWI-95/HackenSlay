namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Bullet
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public bool IsActive { get; set; }

    public Bullet(Vector2 position, Vector2 velocity)
    {
        Position = position;
        Velocity = velocity;
        IsActive = true;
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // Füge Logik hinzu, um die Aktivität des Projektils zu überprüfen
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        // Zeichne das Projektil
    }
}
