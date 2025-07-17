namespace HackenSlay;

/// <summary>
/// Generic alien enemy with unusual abilities.
/// </summary>
public class Alien : Enemy
{
    public Alien() : base("Alien")
    {
        _health = 5;
        _strength = 2;
        _walkspeed = 1.4f;
    }
}
