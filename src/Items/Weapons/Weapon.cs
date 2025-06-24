namespace HackenSlay;

using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Weapon : TextureObject
{
    public int Damage { get; set; }
    public float FireRate { get; set; }
    public float Range { get; set; }


    public List<Bullet> Bullets;

    public Weapon(int damage, float fireRate, float range)
        : base()
    {
        Damage = damage;
        FireRate = fireRate;
        Range = range;
    }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
    }

    public virtual void Draw(GameHS game, SpriteBatch spriteBatch)
    {
    }
}
