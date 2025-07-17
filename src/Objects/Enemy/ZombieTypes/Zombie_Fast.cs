namespace HackenSlay;

/// <summary>
/// Agile zombie that moves quickly but has less health.
/// </summary>
public class Zombie_Fast : Zombie
{
    public Zombie_Fast()
    {
        _name = "Fast Zombie";
        _health = 4;
        _walkspeed = 2f;
    }
}
