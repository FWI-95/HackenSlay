using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Standard assault robot with balanced attributes.
/// </summary>
public class Robot_Assault : Robot
{
    public Robot_Assault()
    {
        _name = "Assault Robot";
        _health = 10;
        _strength = 5;
        _walkspeed = 1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
