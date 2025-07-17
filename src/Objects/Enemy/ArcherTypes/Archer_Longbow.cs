namespace HackenSlay;

/// <summary>
/// Archer using a longbow with greater strength but slower speed.
/// </summary>
public class Archer_Longbow : Archer
{
    public Archer_Longbow()
    {
        _name = "Longbow Archer";
        _strength = 3;
        _walkspeed = 1f;
    }
}
