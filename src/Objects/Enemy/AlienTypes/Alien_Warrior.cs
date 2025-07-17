namespace HackenSlay;

/// <summary>
/// Standard alien warrior with balanced stats.
/// </summary>
public class Alien_Warrior : Alien
{
    public Alien_Warrior()
    {
        _name = "Alien Warrior";
        _health = 6;
        _strength = 3;
        _walkspeed = 1.6f;
    }
}
