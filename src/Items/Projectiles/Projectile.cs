using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;

namespace HackenSlay;

public abstract class Projectile : TextureObject
{
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float Range { get; set; }
    public Vector2 Direction { get; set; }

    private float _distanceTravelled;

    protected Projectile(Vector2 position, Vector2 direction, float speed, float range, float damage)
    {
        _pos = position;
        Direction = direction;
        if (Direction != Vector2.Zero)
            Direction.Normalize();
        Speed = speed;
        Range = range;
        Damage = damage;
        _isActive = true;
        _isVisible = true;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        if (!_isActive)
            return;

        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Vector2 movement = Direction * Speed * delta;
        _pos += movement;
        _distanceTravelled += movement.Length();

        if (_distanceTravelled >= Range)
            _isActive = false;

        if (_pos.X < 0 || _pos.X > game.Window.ClientBounds.Width ||
            _pos.Y < 0 || _pos.Y > game.Window.ClientBounds.Height)
        {
            _isActive = false;
        }
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        base.Draw(game, spriteBatch);
    }
}
