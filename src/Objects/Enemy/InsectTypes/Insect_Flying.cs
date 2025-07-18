using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Flying insect enemy with high mobility.
/// </summary>
public class Insect_Flying : Insect
{
    public Insect_Flying()
    {
        _name = "Flying Insect";
        _health = 2;
        _walkspeed = 3f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
