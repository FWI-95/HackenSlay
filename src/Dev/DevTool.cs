using Microsoft.Xna.Framework;

namespace HackenSlay;

public static class DevTool
{
    public static Weapon SpawnWeapon(string weaponName)
    {
        switch (weaponName.ToLower())
        {
            case "dummy":
                return new DummyWeapon();
            default:
                Debug.Log($"Not implemented yet: {weaponName}", DebugLevel.LOW, DebugCategory.WEAPON);
                return null;
        }
    }

    public static Item SpawnItem(string itemName)
    {
        switch (itemName.ToLower())
        {
            case "dummy":
                return new DummyItem();
            default:
                Debug.Log($"Not implemented yet: {itemName}", DebugLevel.LOW, DebugCategory.ITEM);
                return null;
        }
    }

    public static Enemy SpawnEnemy(string enemyName)
    {
        Debug.Log($"Not implemented yet: {enemyName}", DebugLevel.LOW, DebugCategory.ENEMY);
        return new Enemy(enemyName);
    }
}
