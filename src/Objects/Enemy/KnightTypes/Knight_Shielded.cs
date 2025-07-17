namespace HackenSlay;

/// <summary>
/// Knight with a large shield providing extra health but slower speed.
/// </summary>
public class Knight_Shielded : Knight
{
    public Knight_Shielded()
    {
        _name = "Shielded Knight";
        _health = 10;
        _walkspeed = 0.8f;
    }
}
