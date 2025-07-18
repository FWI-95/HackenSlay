using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Lightweight alien that scouts ahead quickly.
/// </summary>
public class Alien_Scout : Alien
{
    public Alien_Scout()
    {
        _name = "Alien Scout";
        _health = 3;
        _walkspeed = 2.2f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
