/// <summary>
/// Represents the controllable player character.
/// </summary>

using System;
using System.Text.Json;
using HackenSlay.Core.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;
using HackenSlay.Core.Dev;
using HackenSlay.Core.Player;
using Debug = HackenSlay.Core.Dev.Debug;

namespace HackenSlay;

/// <summary>
/// Base player object containing movement and action logic.
/// </summary>
public class Player : AnimationObject
{
    ItemActionHandler itemActionHandler;
    private Weapon _currentWeapon;
    public Inventory Inventory { get; } = new Inventory();
    public Weapon CurrentWeapon => _currentWeapon;

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    /// <param name="game">Reference to the main game object.</param>
    public Player(GameHS game) : base()
    {
        LoadJSON("data/character/character_1.json");

        itemActionHandler = new ItemActionHandler(this, game);

        _currentWeapon = new Gun();

        _isActive = true;
        _isVisible = true;

        // add a placeholder item for testing
        Inventory.Add(new DummyItem());
    }

    /// <summary>
    /// Loads all resources for the player.
    /// </summary>
    /// <param name="game">The game instance.</param>
    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);

        _pos = Vector2.Zero;

        _sprite = game.Content.Load<Texture2D>("sprites/missing");
        AnimationHandler.LoadContent(game, _animationdata);
        itemActionHandler.LoadContent(game);
        _currentWeapon.LoadContent(game);
        audioManager.LoadSound(game.Content, "player_attack", "audio/attack");
    }

    /// <summary>
    /// Draws the player and equipped weapon.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="spriteBatch">SpriteBatch used for drawing.</param>
    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {

        AnimationHandler.Draw(game, spriteBatch, this);
        _currentWeapon.Draw(game, spriteBatch);
    }

    /// <summary>
    /// Updates the player logic each frame.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Update(GameHS game, GameTime gameTime)
    {
        base.Update(game, gameTime);

        UpdateAction(game, gameTime);
        UpdateMovement(game, gameTime);
        UpdateAnimation(game, gameTime);
        UpdateStats(game, gameTime);
    }

    /// <summary>
    /// Processes weapon usage and other actions.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public void UpdateAction(GameHS game, GameTime gameTime)
    {
        itemActionHandler.Update(game, gameTime);
        _currentWeapon.Update(game, gameTime);

        if (game.userInput.IsActionPressed("primary_attack"))
        {
            _currentWeapon.Use(_pos, Vector2.Zero, this, game.userInput.GetMousePosition());
            audioManager.PlaySound("player_attack");
        }

        if (game.userInput.IsActionPressed("secondary_attack"))
        {
            itemActionHandler.SecondaryAttack(game);
        }

    }

    /// <summary>
    /// Updates player statistics.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    private void UpdateStats(GameHS game, GameTime gameTime)
    {

    }


    /// <summary>
    /// Updates the player's animations.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    private void UpdateAnimation(GameHS game, GameTime gameTime)
    {
        AnimationHandler.Update(gameTime);
    }



    /// <summary>
    /// Handles player movement input and sets animation state.
    /// </summary>
    /// <param name="game">The game instance.</param>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    private void UpdateMovement(GameHS game, GameTime gameTime)
    {
        _velocity = new Vector2(0, 0); // velocity Stopper -> direkte Bewegung

        if (game.userInput.IsActionPressed("walk_down"))
        {
            _velocity += new Vector2(0, 1);
        }

        if (game.userInput.IsActionPressed("walk_up"))
        {
            _velocity += new Vector2(0, -1);
        }

        if (game.userInput.IsActionPressed("walk_left"))
        {
            _velocity += new Vector2(-1, 0);
        }

        if (game.userInput.IsActionPressed("walk_right"))
        {
            _velocity += new Vector2(1, 0);
        }

        if (_velocity.LengthSquared() != 0)
        {
            _velocity.Normalize();
        }

        if (game.userInput.IsActionPressed("sprint"))
        {
            _velocity *= new Vector2(_runspeed, _runspeed);
        }
        else
        {
            _velocity *= new Vector2(_walkspeed, _walkspeed);
        }

        Debug.Log($"velocity: {_velocity}", DebugLevel.MEDIUM, DebugCategory.PLAYERCALC);

        base.Update(game, gameTime);

        if (_velocity.LengthSquared() == 0) // Vermeidet teure Quadratwurzel-Berechnung
            AnimationHandler._playerState = PlayerState.IDLE;
        else
        {
            if (game.userInput.IsActionPressed("sprint"))
                AnimationHandler._playerState = PlayerState.RUN;
            else
                AnimationHandler._playerState = PlayerState.WALK;
        }

        if (_velocity.X > 0)
            AnimationHandler._playerDirection = PlayerDirection.RIGHT;
        else if (_velocity.X < 0)
            AnimationHandler._playerDirection = PlayerDirection.LEFT;

        if (_velocity.Y > 0)
            AnimationHandler._playerDirection = PlayerDirection.DOWN;
        else if (_velocity.Y < 0)
            AnimationHandler._playerDirection = PlayerDirection.UP;
    }


    /// <summary>
    /// Reads character attributes from a JSON file.
    /// </summary>
    /// <param name="playerData">Path to the JSON file.</param>
    private void LoadJSON(string playerData)
    {
        using JsonDocument? doc = JSONHandler.LoadDocument(playerData);
        if (doc == null)
            return;

        JsonElement root = doc.RootElement;

        _name = root.GetProperty("name").GetString();
        _health = root.GetProperty("health").GetInt32();
        _strength = root.GetProperty("strength").GetInt32();
        _animationdata = root.GetProperty("animationdata").GetString();
        _walkspeed = (float)root.GetProperty("walkspeed").GetDouble();
        _runspeed = (float)root.GetProperty("runspeed").GetDouble();

        Debug.Log($"Name: {_name}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
        Debug.Log($"Health: {_health}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
        Debug.Log($"Strength: {_strength}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
        Debug.Log($"Animation Data: {_animationdata}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
        Debug.Log($"walkspeed: {_walkspeed}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
        Debug.Log($"runspeed: {_runspeed}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
    }
}