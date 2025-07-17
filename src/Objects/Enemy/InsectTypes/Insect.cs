namespace HackenSlay;

/// <summary>
/// Fast but fragile insect-like creature.
/// </summary>
public class Insect : Enemy
{
    public Insect() : base("Insect")
    {
        _health = 2;
        _strength = 1;
        _walkspeed = 2f;
    }
}
