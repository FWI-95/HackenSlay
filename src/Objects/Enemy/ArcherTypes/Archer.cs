namespace HackenSlay;

/// <summary>
/// Base archer enemy that attacks from a distance.
/// </summary>
public class Archer : Enemy
{
    public Archer() : base("Archer")
    {
        _health = 4;
        _strength = 2;
        _walkspeed = 1.2f;
    }
}
