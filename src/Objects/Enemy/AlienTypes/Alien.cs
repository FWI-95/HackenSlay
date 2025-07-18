using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Generic alien enemy with unusual abilities.
/// </summary>
public class Alien : Enemy
{
    public Alien() : base("Alien")
    {
        _health = 5;
        _strength = 2;
        _walkspeed = 1.4f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with Alien sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
