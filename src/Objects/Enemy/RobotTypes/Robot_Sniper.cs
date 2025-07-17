namespace HackenSlay;

/// <summary>
/// Long range robot that moves slowly but hits hard.
/// </summary>
public class Robot_Sniper : Robot
{
    public Robot_Sniper()
    {
        _name = "Sniper Robot";
        _health = 8;
        _strength = 6;
        _walkspeed = 0.7f;
    }
}
