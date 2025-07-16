using Microsoft.Xna.Framework;

namespace HackenSlay;

/// <summary>
/// Very simple enemy that can be damaged and removed from the game.
/// </summary>
public class Enemy : TextureObject
{
    public Enemy(string name)
    {
        _name = name;
        _isActive = true;
        _isVisible = true;
        _health = 3; // a small default value
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        base.Update(game, gameTime);

        if (_health <= 0)
        {
            _isActive = false;
            _isVisible = false;
        }
    }
}
