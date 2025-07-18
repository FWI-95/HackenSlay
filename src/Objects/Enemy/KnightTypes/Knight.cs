using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Armored melee enemy with moderate speed.
/// </summary>
public class Knight : Enemy
{
    public Knight() : base("Knight")
    {
        _health = 7;
        _strength = 3;
        _walkspeed = 1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
