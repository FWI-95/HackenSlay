using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Zombie equipped with melee weapons.
/// </summary>
public class Zombie_Armed : Zombie
{
    public Zombie_Armed()
    {
        _name = "Armed Zombie";
        _health = 5;
        _strength = 2;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
