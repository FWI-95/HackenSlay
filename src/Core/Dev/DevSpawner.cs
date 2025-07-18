using Microsoft.Xna.Framework;

namespace HackenSlay;

public static class DevSpawner
{
    public static Weapon SpawnWeapon(string weaponName)
    {
        return weaponName.ToLower() switch
        {
            "dummy" => new DummyWeapon(),
            "gun" => new Gun(),
            _ => null
        };
    }

    public static Item SpawnItem(Player player, string itemName)
    {
        return itemName.ToLower() switch
        {
            "dummy" => new DummyItem(),
            "bread" => new Bread(player),
            "apple" => new Apple(player),
            "meat" => new Meat(player),
            _ => null
        };
    }

    public static Enemy SpawnEnemy(string enemyName)
    {
        return new Enemy(enemyName);
    }
}
