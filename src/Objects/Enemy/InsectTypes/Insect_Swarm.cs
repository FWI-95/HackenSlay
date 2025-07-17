namespace HackenSlay;

/// <summary>
/// Group of small insects acting as a single enemy.
/// </summary>
public class Insect_Swarm : Insect
{
    public Insect_Swarm()
    {
        _name = "Insect Swarm";
        _health = 3;
        _walkspeed = 2.5f;
    }
}
