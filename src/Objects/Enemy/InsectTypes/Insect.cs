using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Fast but fragile insect-like creature.
/// </summary>
public class Insect : Enemy
{
    public Insect() : base("Insect")
    {
        _health = 2;
        _strength = 1;
        _walkspeed = 2f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
