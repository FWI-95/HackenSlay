using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Generic human soldier enemy.
/// </summary>
public class Soldier : Enemy
{
    public Soldier() : base("Soldier")
    {
        _health = 5;
        _strength = 3;
        _walkspeed = 1.3f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
