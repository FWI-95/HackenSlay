namespace HackenSlay;

/// <summary>
/// Zombie equipped with melee weapons.
/// </summary>
public class Zombie_Armed : Zombie
{
    public Zombie_Armed()
    {
        _name = "Armed Zombie";
        _health = 5;
        _strength = 2;
    }
}
