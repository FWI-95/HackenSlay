using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Giant insect with high health and strength.
/// </summary>
public class Insect_Behemoth : Insect
{
    public Insect_Behemoth()
    {
        _name = "Insect Behemoth";
        _health = 8;
        _strength = 4;
        _walkspeed = 1.5f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
