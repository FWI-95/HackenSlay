using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Standard infantry unit with balanced attributes.
/// </summary>
public class Soldier_Infantry : Soldier
{
    public Soldier_Infantry()
    {
        _name = "Infantry Soldier";
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
