using Microsoft.Xna.Framework.Graphics;

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

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
