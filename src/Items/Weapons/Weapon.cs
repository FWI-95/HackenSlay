namespace HackenSlay;

using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Weapon
{
    public int Damage { get; set; }
    public float FireRate { get; set; }
    public float Range { get; set; }


    public List<Bullet> Bullets;

    public Weapon(int damage, float fireRate, float range)
    {
        Damage = damage;
        FireRate = fireRate;
        Range = range;
    }

    public virtual void Shoot(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
        Bullets.Add(new Bullet(player._pos, target));
    }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
        foreach (Bullet bullet in Bullets)
        {
            if (bullet.IsActive)
            {
                bullet.Update(game, gameTime);
            }
        }
    }

    public virtual void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        foreach (Bullet bullet in Bullets)
        {
            if (bullet.IsActive)
            {
                bullet.Draw(game, spriteBatch);
            }
        }
    }
}
