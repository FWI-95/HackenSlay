/// <summary>
/// Represents the controllable player character.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HackenSlay.Core.Objects;
using HackenSlay.Core.Dev;
using Debug = HackenSlay.Core.Dev.Debug;

namespace HackenSlay;

/// <summary>
/// Base player object containing movement and action logic.
/// </summary>
public class Player : TextureObject
{
    ItemActionHandler itemActionHandler;
    private Weapon _currentWeapon;

    public Player(GameHS game) : base()
    {
        LoadJSON("data/character/character_1.json");

        itemActionHandler = new ItemActionHandler(this, game);

        _currentWeapon = new Gun();

        _isActive = true;
        _isVisible = true;
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);

        _pos = new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);

        _sprite = game.Content.Load<Texture2D>("sprites/missing"); // Todo: missing sprite png is fine, because animationHandler will load the correct sprite. Anyway there is a big box with the missing png on the map and I have no idea why.
        animationHandler.LoadContent(game, _animationdata);
        itemActionHandler.LoadContent(game);
        _currentWeapon.LoadContent(game);
        AudioManager.LoadSoundEffect(game.Content, "attack", "audio/attack");
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        // base.Draw(game, spriteBatch);

        animationHandler.Draw(game, spriteBatch, this);
        _currentWeapon.Draw(game, spriteBatch);
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        base.Update(game, gameTime);

        UpdateAction(game, gameTime);
        UpdateMovement(game, gameTime);
        UpdateAnimation(game, gameTime);
        UpdateStats(game, gameTime);
    }

    public void UpdateAction(GameHS game, GameTime gameTime)
    {
        itemActionHandler.Update(game, gameTime);
        _currentWeapon.Update(game, gameTime);

        if (game.userInput.IsActionPressed("primary_attack"))
        {
            _currentWeapon.Use(_pos, Vector2.Zero, this, game.userInput.GetMousePosition());
            AudioManager.PlaySoundEffect("attack");
        }

        if (game.userInput.IsActionPressed("secondary_attack"))
        {
            itemActionHandler.SecondaryAttack(game);
        }

        // if (game.userInput.IsActionPressed("drop_item"))
        // {
        //     itemActionHandler.DropItem(game);
        // }

        // if (game.userInput.IsActionPressed("open_inventory"))
        // {
        //     itemActionHandler.OpenInventory(game);
        // }
    }

    private void UpdateStats(GameHS game, GameTime gameTime)
    {

    }

    private void UpdateAnimation(GameHS game, GameTime gameTime)
    {
        animationHandler.Update(gameTime);
    }

    // Todo: refactor this method to use the new animationHandler
    // This method is currently updating the player movement and animation state based on user input.
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
            // Debug.Log("Das Sprite steht still.");
            animationHandler._playerState = PlayerState.IDLE;
        else
        {
            // Debug.Log("Das Sprite bewegt sich.");
            if (game.userInput.IsActionPressed("sprint"))
                animationHandler._playerState = PlayerState.RUN;
            else
                animationHandler._playerState = PlayerState.WALK;
        }

        if (_velocity.X > 0)
            // Debug.Log("Bewegt sich nach rechts.");
            animationHandler._playerDirection = PlayerDirection.RIGHT;
        else if (_velocity.X < 0)
            // Debug.Log("Bewegt sich nach links.");
            animationHandler._playerDirection = PlayerDirection.LEFT;

        if (_velocity.Y > 0)
            // Debug.Log("Bewegt sich nach unten.");
            animationHandler._playerDirection = PlayerDirection.DOWN;
        else if (_velocity.Y < 0)
            // Debug.Log("Bewegt sich nach oben.");
            animationHandler._playerDirection = PlayerDirection.UP;
    }

    private void LoadJSON(string playerData)
    {

        if (File.Exists(playerData))
        {
            // JSON aus der Datei lesen
            string jsonString = File.ReadAllText(playerData);

            // JSON parsen und Daten auslesen
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                // Werte aus der JSON auslesen
                _name = root.GetProperty("name").GetString();
                _health = root.GetProperty("health").GetInt32();
                _strength = root.GetProperty("strength").GetInt32();
                _animationdata = root.GetProperty("animationdata").GetString();
                _walkspeed = (float)root.GetProperty("walkspeed").GetDouble();
                _runspeed = (float)root.GetProperty("runspeed").GetDouble();

                // Ausgabe der Werte
                Debug.Log($"Name: {_name}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Health: {_health}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Strength: {_strength}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Animation Data: {_animationdata}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"walkspeed: {_walkspeed}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"runspeed: {_runspeed}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
            }
        }
    }
}