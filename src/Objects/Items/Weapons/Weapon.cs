using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;

namespace HackenSlay;

public class Weapon : TextureObject
{
    public int Damage { get; set; }
    public float FireRate { get; set; }
    public float Range { get; set; }


    public List<Projectile> Projectiles;

    public Weapon(int damage, float fireRate, float range)
        : base()
    {
        Damage = damage;
        FireRate = fireRate;
        Range = range;
        Projectiles = new List<Projectile>();
    }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
    }

    public virtual void Draw(GameHS game, SpriteBatch spriteBatch)
    {
    }

    public virtual void Use(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
    }
}
