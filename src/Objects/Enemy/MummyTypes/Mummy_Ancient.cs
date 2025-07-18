using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Ancient mummy with exceptional resilience.
/// </summary>
public class Mummy_Ancient : Mummy
{
    public Mummy_Ancient()
    {
        _name = "Ancient Mummy";
        _health = 12;
        _walkspeed = 0.6f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
