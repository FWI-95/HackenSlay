using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Highly trained knight with improved stats.
/// </summary>
public class Knight_Elite : Knight
{
    public Knight_Elite()
    {
        _name = "Elite Knight";
        _health = 8;
        _strength = 4;
        _walkspeed = 1.1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
