namespace HackenSlay;

/// <summary>
/// Simple bread restoring a small amount of health.
/// </summary>
public class Bread : Food
{
    public Bread(Player player) : base(player, 10)
    {
        _name = "Bread";
    }
}
