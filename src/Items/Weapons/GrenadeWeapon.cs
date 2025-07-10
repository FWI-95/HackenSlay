namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class GrenadeWeapon : Weapon
{
    public float ExplosionRadius { get; set; }
    public float FuseTime { get; set; }

    public GrenadeWeapon(int damage, float fireRate, float range, float explosionRadius, float fuseTime)
        : base(damage, fireRate, range)
    {
        ExplosionRadius = explosionRadius;
        FuseTime = fuseTime;
        Projectiles = new List<Projectile>();
    }

    public override void Use(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
        // Temporär dieselbe Bullet nutzen – später durch Grenade-Klasse ersetzen
        const float speed = 300f;
        var grenade = new Bullet(position, target, speed, Range, Damage);
        Projectiles.Add(grenade);
        Console.WriteLine($"Grenade thrown by player at {player._pos} towards {target} (fuse: {FuseTime}s)");
    }
}
