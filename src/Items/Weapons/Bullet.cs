namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Bullet : TextureObject
{

    public Bullet(Vector2 position, Vector2 velocity)
    {
        _pos = position;
        _velocity = velocity;
        _isActive = true;
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        _pos += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // Füge Logik hinzu, um die Aktivität des Projektils zu überprüfen

        if (_pos.X < 0 || _pos.X > game.Window.ClientBounds.Width ||
            _pos.Y < 0 || _pos.Y > game.Window.ClientBounds.Height)
        {
            _isActive = false; // Deaktivieren, wenn außerhalb des Bildschirms
        }

        //TODO: Implementiere Logik, um zu überprüfen, ob das Projektil ein Ziel getroffen hat
        // Check Collision with Enemy list
        // if (game.EnemyList.Any(enemy => enemy.Bounds.Contains(_pos)))
        // {
        //     _isActive = false; // Deaktivieren, wenn es einen Treffer gibt
        //     enemy.TakeDamage(Damage); // Angenommen, es gibt eine TakeDamage-Methode
        //     Debug.Log($"Bullet hit enemy at position: {_pos}", DebugLevel.HIGH, DebugCategory.BULLET);
        // }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        // Zeichne das Projektil
        base.Draw(game, spriteBatch);
    }
}
