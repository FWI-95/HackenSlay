using Microsoft.Xna.Framework;
using HackenSlay.Core.Objects;
using HackenSlay.World.Map;
using HackenSlay.World.Navigation;

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
        _walkspeed = 1f;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
        AudioManager.LoadSoundEffect(game.Content, "die", "audio/enemy_die");
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        if (_health <= 0)
        {
            audioManager.PlaySound("enemy_die");
            _isActive = false;
            _isVisible = false;
            AudioManager.PlaySoundEffect("die");
            return;
        }

        _velocity = CalculateVelocity(game.MapTiles, game.TileSize, game.player._pos);

        base.Update(game, gameTime);
    }

    internal Vector2 CalculateVelocity(TileType[,] map, int tileSize, Vector2 target)
    {
        var start = new Point((int)(_pos.X / tileSize), (int)(_pos.Y / tileSize));
        var goal = new Point((int)(target.X / tileSize), (int)(target.Y / tileSize));

        var path = Pathfinder.FindPath(map, start, goal);
        if (path.Count < 2)
            return Vector2.Zero;

        var next = path[1];
        Vector2 destination = new Vector2(next.X * tileSize, next.Y * tileSize);
        Vector2 dir = destination - _pos;
        if (dir.LengthSquared() > 0)
        {
            dir.Normalize();
            return dir * _walkspeed;
        }

        return Vector2.Zero;
    }
}
