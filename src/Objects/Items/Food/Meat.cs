namespace HackenSlay;

/// <summary>
/// Hearty meat restoring a larger amount of health.
/// </summary>
public class Meat : Food
{
    public Meat(Player player) : base(player, 20)
    {
        _name = "Meat";
    }
}
