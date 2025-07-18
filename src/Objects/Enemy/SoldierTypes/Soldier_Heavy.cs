using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Soldier equipped with heavy armor and weapons.
/// </summary>
public class Soldier_Heavy : Soldier
{
    public Soldier_Heavy()
    {
        _name = "Heavy Soldier";
        _health = 9;
        _strength = 5;
        _walkspeed = 0.9f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
