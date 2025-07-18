using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Long range robot that moves slowly but hits hard.
/// </summary>
public class Robot_Sniper : Robot
{
    public Robot_Sniper()
    {
        _name = "Sniper Robot";
        _health = 8;
        _strength = 6;
        _walkspeed = 0.7f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
