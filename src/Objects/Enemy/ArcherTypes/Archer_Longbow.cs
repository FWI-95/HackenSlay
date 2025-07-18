using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Archer using a longbow with greater strength but slower speed.
/// </summary>
public class Archer_Longbow : Archer
{
    public Archer_Longbow()
    {
        _name = "Longbow Archer";
        _strength = 3;
        _walkspeed = 1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
