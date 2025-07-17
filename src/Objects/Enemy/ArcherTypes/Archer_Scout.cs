namespace HackenSlay;

/// <summary>
/// Fast archer with low health used for scouting.
/// </summary>
public class Archer_Scout : Archer
{
    public Archer_Scout()
    {
        _name = "Scout Archer";
        _health = 3;
        _walkspeed = 2f;
    }
}
