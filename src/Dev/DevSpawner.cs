using Microsoft.Xna.Framework;

namespace HackenSlay;

public static class DevSpawner
{
    public static Weapon SpawnWeapon(string weaponName)
    {
        return weaponName.ToLower() switch
        {
            "dummy" => new DummyWeapon(),
            _ => null
        };
    }

    public static Item SpawnItem(string itemName)
    {
        return itemName.ToLower() switch
        {
            "dummy" => new DummyItem(),
            _ => null
        };
    }

    public static Enemy SpawnEnemy(string enemyName)
    {
        return new Enemy(enemyName);
    }
}
