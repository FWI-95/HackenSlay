namespace HackenSlay;

/// <summary>
/// Generic human soldier enemy.
/// </summary>
public class Soldier : Enemy
{
    public Soldier() : base("Soldier")
    {
        _health = 5;
        _strength = 3;
        _walkspeed = 1.3f;
    }
}
