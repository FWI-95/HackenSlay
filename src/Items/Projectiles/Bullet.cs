using Microsoft.Xna.Framework;

namespace HackenSlay;

public class Bullet : Projectile
{
    public Bullet(Vector2 position, Vector2 target, float speed, float range, float damage)
        : base(position, target - position, speed, range, damage)
    {
    }
}
