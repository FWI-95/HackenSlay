namespace HackenSlay;

/// <summary>
/// Armored melee enemy with moderate speed.
/// </summary>
public class Knight : Enemy
{
    public Knight() : base("Knight")
    {
        _health = 7;
        _strength = 3;
        _walkspeed = 1f;
    }
}
