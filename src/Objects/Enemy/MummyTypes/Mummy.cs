namespace HackenSlay;

/// <summary>
/// Slow undead enemy wrapped in bandages.
/// </summary>
public class Mummy : Enemy
{
    public Mummy() : base("Mummy")
    {
        _health = 8;
        _strength = 2;
        _walkspeed = 0.7f;
    }
}
