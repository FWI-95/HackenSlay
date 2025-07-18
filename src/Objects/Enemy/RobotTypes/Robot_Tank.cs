using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Heavy robot with very high health but extremely slow.
/// </summary>
public class Robot_Tank : Robot
{
    public Robot_Tank()
    {
        _name = "Tank Robot";
        _health = 20;
        _strength = 4;
        _walkspeed = 0.5f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
