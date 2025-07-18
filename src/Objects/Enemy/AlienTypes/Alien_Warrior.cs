using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Standard alien warrior with balanced stats.
/// </summary>
public class Alien_Warrior : Alien
{
    public Alien_Warrior()
    {
        _name = "Alien Warrior";
        _health = 6;
        _strength = 3;
        _walkspeed = 1.6f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
