using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;

namespace HackenSlay;

/// <summary>
/// Base zombie enemy with average stats.
/// </summary>
public class Zombie : Enemy
{
    public Zombie() : base("Zombie")
    {
        _health = 5;
        _strength = 1;
        _walkspeed = 1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
