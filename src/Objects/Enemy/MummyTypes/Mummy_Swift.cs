namespace HackenSlay;

/// <summary>
/// Faster mummy variant with reduced health.
/// </summary>
public class Mummy_Swift : Mummy
{
    public Mummy_Swift()
    {
        _name = "Swift Mummy";
        _health = 6;
        _walkspeed = 1.2f;
    }
}
