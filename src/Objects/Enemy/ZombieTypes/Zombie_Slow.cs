using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Slow but sturdy zombie.
/// </summary>
public class Zombie_Slow : Zombie
{
    public Zombie_Slow()
    {
        _name = "Slow Zombie";
        _health = 6;
        _walkspeed = 0.5f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
