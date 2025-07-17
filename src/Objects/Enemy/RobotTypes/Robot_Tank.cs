namespace HackenSlay;

/// <summary>
/// Heavy robot with very high health but extremely slow.
/// </summary>
public class Robot_Tank : Robot
{
    public Robot_Tank()
    {
        _name = "Tank Robot";
        _health = 20;
        _strength = 4;
        _walkspeed = 0.5f;
    }
}
