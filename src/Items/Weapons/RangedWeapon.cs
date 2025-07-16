using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using HackenSlay.Core.Objects;

namespace HackenSlay;

public class RangedWeapon : Weapon
{
    public int MagazineSize { get; set; }
    public int RemainingBullets { get; set; }
    public int RemainingMagazines { get; set; }
    public int BulletsPerShoot { get; set; }
    public int BulletsShotThisShoot { get; set; }
    public float BulletSpeed { get; set; }
    public Boolean IsShooting { get; set; }
    public Boolean IsReloading { get; set; }
    public int TimeSinceLastBullet { get; set; }
    public int TimeForReload { get; set; }
    public int ElapsedTimeReload { get; set; }
    public Boolean AutoReload { get; set; }


    public RangedWeapon(int damage, float fireRate, float range)
        : base(damage, fireRate, range)
    {
        Projectiles = new List<Projectile>();
    }

    public override void Update(GameHS game, GameTime gameTime)
    {

        // Update all bullets
        for (int i = Projectiles.Count - 1; i >= 0; i--)
        {
            var projectile = Projectiles[i];
            projectile.Update(game, gameTime);

            // simple collision detection with enemies
            foreach (var obj in game.Objects)
            {
                if (obj is Enemy enemy && enemy._isActive)
                {
                    Rectangle bulletRect = new Rectangle((int)projectile._pos.X, (int)projectile._pos.Y,
                        projectile._sprite.Width, projectile._sprite.Height);
                    Rectangle enemyRect = new Rectangle((int)enemy._pos.X, (int)enemy._pos.Y,
                        enemy._sprite.Width, enemy._sprite.Height);
                    if (bulletRect.Intersects(enemyRect))
                    {
                        enemy._health -= (int)projectile.Damage;
                        projectile._isActive = false;
                        break;
                    }
                }
            }

            if (!projectile._isActive)
            {
                Projectiles.RemoveAt(i);
            }
        }

        // track the elapsed time since the last bullet was fired
        TimeSinceLastBullet += gameTime.ElapsedGameTime.Milliseconds;

        // Input checks, e.g. for shooting and reloading

        // if reloading, then add gameTime to elapsedTimeReload. If ElapsedTimeReload >= TimeForReload, then set IsReloading to false, RemainingBullets = MagazineSize, RemainingMagazines--, ElapsedTimeReload = 0
        if (IsReloading)
        {
            ElapsedTimeReload += gameTime.ElapsedGameTime.Milliseconds;
            if (ElapsedTimeReload >= TimeForReload)
            {
                IsReloading = false;
                RemainingBullets = MagazineSize;
                RemainingMagazines--;
                ElapsedTimeReload = 0;
            }
            return; // Skip the rest of the update if reloading
        }

        // if RemainingBullets <= 0, or BulletsPerShoot >= BulletsPerShoot, then dont return
        if (RemainingBullets <= 0 || BulletsShotThisShoot >= BulletsPerShoot)
        {
            // IsShooting = false; // Stop shooting if no bullets left or max bullets shot
            return;
        }

        // Check if the weapon is shooting
        if (IsShooting && RemainingBullets > 0 && TimeSinceLastBullet >= FireRate)
        {
            // Create a new bullet and add it to the list
            Bullet newBullet = new Bullet(_pos, game.userInput.GetMousePosition(), BulletSpeed, Range, Damage);
            newBullet.LoadContent(game);
            Projectiles.Add(newBullet);
            BulletsShotThisShoot++;
            RemainingBullets--;

            // Reset the time since the last bullet
            TimeSinceLastBullet = 0;

            // Check if we have shot all bullets for this shoot
            if (BulletsShotThisShoot >= BulletsPerShoot)
            {
                IsShooting = false; // Stop shooting after the defined number of bullets
                BulletsShotThisShoot = 0; // Reset for the next shoot
            }
        }



    }
    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        // Draw all active projectiles
        foreach (var projectile in Projectiles)
        {
            projectile.Draw(game, spriteBatch);
        }
    }
}
