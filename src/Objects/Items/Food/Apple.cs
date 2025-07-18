namespace HackenSlay;

/// <summary>
/// Juicy apple restoring a small amount of health.
/// </summary>
public class Apple : Food
{
    public Apple(Player player) : base(player, 5)
    {
        _name = "Apple";
    }
}
