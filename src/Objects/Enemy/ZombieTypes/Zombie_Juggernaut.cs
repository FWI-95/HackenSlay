namespace HackenSlay;

/// <summary>
/// Large zombie with high health and slow speed.
/// </summary>
public class Zombie_Juggernaut : Zombie
{
    public Zombie_Juggernaut()
    {
        _name = "Juggernaut Zombie";
        _health = 10;
        _walkspeed = 0.8f;
        _strength = 3;
    }
}
