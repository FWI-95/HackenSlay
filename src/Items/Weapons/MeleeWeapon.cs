namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class MeleeWeapon : Weapon
{
    public float AttackRadius { get; set; }

    public MeleeWeapon(int damage, float fireRate, float range, float attackRadius)
        : base(damage, fireRate, range)
    {
        AttackRadius = attackRadius;
        Bullets = new List<Bullet>();
    }

    public override void Use(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
        // Melee attack has no bullet – simulate instant hit in radius
        // This could be expanded with hit detection vs. nearby enemies
        Console.WriteLine($"Melee attack by player at {player._pos} towards {target} with radius {AttackRadius}");
        // Optional: Add visual effect or short-lived slash "bullet"
    }
}
