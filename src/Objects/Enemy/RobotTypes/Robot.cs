namespace HackenSlay;

/// <summary>
/// Robust mechanical enemy often encountered as a mini boss.
/// </summary>
public class Robot : Enemy
{
    public Robot() : base("Robot")
    {
        _health = 12;
        _strength = 4;
        _walkspeed = 0.9f;
    }
}
