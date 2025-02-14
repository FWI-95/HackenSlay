using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay;

public class Player : TextureObject
{
    Vector2 velocity;
    AnimationHandler animationHandler;
    public string _name { get; set; }
    public int _health { get; set; }
    public int _strength { get; set; }
    public string _animationdata { get; set; }

    public Player(GameHS game) : base(game)
    {
        velocity = new Vector2(0, 0);
        animationHandler = new AnimationHandler();

        LoadJSON("data/character/character_1.json");
    }

    public override void LoadContent(GameHS game)
    {
        _sprite = game.Content.Load<Texture2D>("sprites/player");
        animationHandler.LoadContent(game, _animationdata);
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        // base.Draw(game, spriteBatch);

        animationHandler.Draw(game, spriteBatch, this);
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        base.Update(game, gameTime);

        UpdateMovement(game, gameTime);
        UpdateAnimation(game, gameTime);
        UpdateStats(game, gameTime);
    }

    private void UpdateStats(GameHS game, GameTime gameTime)
    {

    }

    private void UpdateAnimation(GameHS game, GameTime gameTime)
    {
        animationHandler.Update(gameTime);
    }

    private void UpdateMovement(GameHS game, GameTime gameTime)
    {
        velocity = new Vector2(0, 0); // velocity Stopper -> direkte Bewegung

        float multiplicator = 4;

        if (game.userInput.Shift())
        {
            multiplicator = 7f;
        }

        if (game.userInput.Down())
        {
            velocity += new Vector2(0, multiplicator);
        }

        if (game.userInput.Up())
        {
            velocity += new Vector2(0, multiplicator * -1);
        }

        if (game.userInput.Left())
        {
            velocity += new Vector2(multiplicator * -1, 0);
        }

        if (game.userInput.Right())
        {
            velocity += new Vector2(multiplicator, 0);
        }

        Vector2 newPos = _pos + velocity;

        if (newPos.X + animationHandler.getSubImage().Width > game.Window.ClientBounds.X
            || newPos.X < 0
            || newPos.Y + animationHandler.getSubImage().Height > game.Window.ClientBounds.Y
            || newPos.Y < 0)
        {
            velocity = new Vector2(0, 0);
        }

        _pos += velocity;

        if (velocity.LengthSquared() == 0) // Vermeidet teure Quadratwurzel-Berechnung
            // Debug.Log("Das Sprite steht still.");
            animationHandler._playerState = State.IDLE;
        else
        {
            // Debug.Log("Das Sprite bewegt sich.");
            if (game.userInput.Shift())
                animationHandler._playerState = State.RUN;
            else
                animationHandler._playerState = State.WALK;
        }

        if (velocity.X > 0)
            // Debug.Log("Bewegt sich nach rechts.");
            animationHandler._playerDirection = Direction.RIGHT;
        else if (velocity.X < 0)
            // Debug.Log("Bewegt sich nach links.");
            animationHandler._playerDirection = Direction.LEFT;

        if (velocity.Y > 0)
            // Debug.Log("Bewegt sich nach unten.");
            animationHandler._playerDirection = Direction.DOWN;
        else if (velocity.Y < 0)
            // Debug.Log("Bewegt sich nach oben.");
            animationHandler._playerDirection = Direction.UP;
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
                string name = root.GetProperty("name").GetString();
                int health = root.GetProperty("health").GetInt32();
                int strength = root.GetProperty("strength").GetInt32();
                string animationData = root.GetProperty("animationdata").GetString();

                // Ausgabe der Werte
                Debug.Log($"Name: {name}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Health: {health}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Strength: {strength}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
                Debug.Log($"Animation Data: {animationData}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);

                _name = name;
                _health = health;
                _strength = strength;
                _animationdata = animationData;
            }
        }
    }
}