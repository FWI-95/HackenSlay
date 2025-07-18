using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Archer equipped with a crossbow, has balanced stats.
/// </summary>
public class Archer_Crossbow : Archer
{
    public Archer_Crossbow()
    {
        _name = "Crossbow Archer";
        _health = 5;
        _strength = 2;
        _walkspeed = 1.2f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
