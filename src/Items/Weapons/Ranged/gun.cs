using Microsoft.Xna.Framework;

namespace HackenSlay;

public class Gun : RangedWeapon
{
    public Gun() : base(10, 200f, 800f)
    {
        MagazineSize = 8;
        RemainingBullets = MagazineSize;
        RemainingMagazines = 99;
        BulletsPerShoot = 1;
        BulletSpeed = 600f;
        TimeForReload = 1500;
        AutoReload = true;
    }

    public override void Use(Vector2 position, Vector2 direction, Player player, Vector2 target)
    {
        _pos = position;
        if (RemainingBullets <= 0)
        {
            if (AutoReload && !IsReloading)
                IsReloading = true;
            return;
        }

        IsShooting = true;
    }
}
