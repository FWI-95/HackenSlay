namespace HackenSlay;

/// <summary>
/// Slow but sturdy zombie.
/// </summary>
public class Zombie_Slow : Zombie
{
    public Zombie_Slow()
    {
        _name = "Slow Zombie";
        _health = 6;
        _walkspeed = 0.5f;
    }
}
