namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class RangedWeapon : Weapon
{
    public RangedWeapon(int damage, float fireRate, float range)
        : base(damage, fireRate, range)
    {
        Bullets = new List<Bullet>();
    }

    public override void Shoot(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
        // Standard bullet firing
        Bullets.Add(new Bullet(player._pos, target));
    }
}
