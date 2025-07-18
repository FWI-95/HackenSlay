using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Base archer enemy that attacks from a distance.
/// </summary>
public class Archer : Enemy
{
    public Archer() : base("Archer")
    {
        _health = 4;
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
