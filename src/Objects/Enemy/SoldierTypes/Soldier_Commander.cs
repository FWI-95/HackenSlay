using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Experienced commander with higher health and strength.
/// </summary>
public class Soldier_Commander : Soldier
{
    public Soldier_Commander()
    {
        _name = "Soldier Commander";
        _health = 7;
        _strength = 4;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
