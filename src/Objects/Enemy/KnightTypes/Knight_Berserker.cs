namespace HackenSlay;

/// <summary>
/// Aggressive knight that sacrifices defense for strength.
/// </summary>
public class Knight_Berserker : Knight
{
    public Knight_Berserker()
    {
        _name = "Berserker Knight";
        _health = 6;
        _strength = 5;
        _walkspeed = 1.2f;
    }
}
