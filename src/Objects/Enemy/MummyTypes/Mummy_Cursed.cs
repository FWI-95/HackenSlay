using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Mummy cursed with dark magic, dealing extra damage.
/// </summary>
public class Mummy_Cursed : Mummy
{
    public Mummy_Cursed()
    {
        _name = "Cursed Mummy";
        _strength = 4;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
