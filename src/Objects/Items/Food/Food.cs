namespace HackenSlay;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Base class for consumable food items that restore player health.
/// </summary>
public abstract class Food : Item
{
    /// <summary>
    /// Amount of health restored when consumed.
    /// </summary>
    public int HealAmount { get; }
    private readonly Player _player;

    protected Food(Player player, int healAmount)
        : base()
    {
        _player = player;
        HealAmount = healAmount;
        _isActive = true;
        _isVisible = true;
        Size = new Vector2(16, 16);
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        if (!_isActive)
            return;

        var player = _player ?? game?.player;
        if (player == null)
            return;

        Rectangle itemRect = new Rectangle((int)_pos.X, (int)_pos.Y, (int)Size.X, (int)Size.Y);
        Rectangle playerRect = new Rectangle((int)player._pos.X, (int)player._pos.Y, (int)player.Size.X, (int)player.Size.Y);
        if (itemRect.Intersects(playerRect))
        {
            player.Inventory.Add(this);
            _isActive = false;
            _isVisible = false;
        }
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible)
            return;

        spriteBatch.Draw(_sprite, _pos, Color.White);
    }

    /// <summary>
    /// Consume the food item and heal the player.
    /// </summary>
    public override void Handle(GameHS game)
    {
        var player = _player ?? game?.player;
        if (player == null)
            return;

        player._health += HealAmount;
        player.Inventory.Remove(this);
    }
}
