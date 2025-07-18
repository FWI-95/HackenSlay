using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

/// <summary>
/// Alien with psionic abilities dealing high strength damage.
/// </summary>
public class Alien_Psi : Alien
{
    public Alien_Psi()
    {
        _name = "Alien Psi";
        _health = 4;
        _strength = 5;
        _walkspeed = 1.2f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        // UserTodo: replace with correct sprite
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
    }

}
