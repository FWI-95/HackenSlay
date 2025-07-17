namespace HackenSlay;

/// <summary>
/// Archer equipped with a crossbow, has balanced stats.
/// </summary>
public class Archer_Crossbow : Archer
{
    public Archer_Crossbow()
    {
        _name = "Crossbow Archer";
        _health = 5;
        _strength = 2;
        _walkspeed = 1.2f;
    }
}
