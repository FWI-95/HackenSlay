/// <summary>
/// Manages animations for texture objects and loads animation data from JSON.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure - Animation should get it's own category, like Animation/AnimationHandler, Animation/Animation, etc.
// Vorlage ist wie immer eine GameEngine, nach der die ganzen Bestandteile abgeleitet werden können

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Text.Json.Nodes;
using System.Collections;
using HackenSlay;
using HackenSlay.Core.Objects;
using HackenSlay.Core.Dev;

namespace HackenSlay.Core.Animation;

/// <summary>
/// Provides functionality to load, update and draw animations for objects.
/// </summary>
public class AnimationHandler
{
    private Texture2D _spriteSheet;
    private readonly Dictionary<(PlayerState, PlayerDirection), Animation> _animations;
    public PlayerDirection _playerDirection { get; set; }
    public PlayerState _playerState { get; set; }
    public string assetName { get; private set; }
    private int _targetWidth;
    private int _targetHeight;

    /// <summary>
    /// Gets the width of animation frames after resizing.
    /// </summary>
    public int FrameWidth => _targetWidth;

    /// <summary>
    /// Gets the height of animation frames after resizing.
    /// </summary>
    public int FrameHeight => _targetHeight;
    public AnimationHandler()
    {
        _animations = new Dictionary<(PlayerState, PlayerDirection), Animation>();
    }

    /// <summary>
    /// Loads animation data and associated sprite sheet assets.
    /// Optionally resizes the loaded texture to the desired dimensions.
    /// </summary>
    /// <param name="game">The running game instance.</param>
    /// <param name="animationData">Path to the JSON animation file.</param>
    /// <param name="width">Desired frame width.</param>
    /// <param name="height">Desired frame height.</param>
    public void LoadContent(GameHS game, string animationData, int width = 0, int height = 0)
    {
        LoadJSON(animationData);

        _spriteSheet = game.Content.Load<Texture2D>(assetName);

        if (width > 0 && height > 0)
        {
            _spriteSheet = ResizeTexture(game.GraphicsDevice, _spriteSheet, width, height);
            _targetWidth = width;
            _targetHeight = height;
        }
        else
        {
            _targetWidth = GetSubImage().Width;
            _targetHeight = GetSubImage().Height;
        }
    }

    /// <summary>
    /// Returns a resized copy of the given texture.
    /// </summary>
    private static Texture2D ResizeTexture(GraphicsDevice device, Texture2D texture, int width, int height)
    {
        RenderTarget2D renderTarget = new RenderTarget2D(device, width, height);
        SpriteBatch batch = new SpriteBatch(device);
        device.SetRenderTarget(renderTarget);
        device.Clear(Color.Transparent);
        batch.Begin();
        batch.Draw(texture, new Rectangle(0, 0, width, height), Color.White);
        batch.End();
        device.SetRenderTarget(null);

        Texture2D result = new Texture2D(device, width, height);
        Color[] data = new Color[width * height];
        renderTarget.GetData(data);
        result.SetData(data);
        batch.Dispose();
        renderTarget.Dispose();
        return result;
    }

    /// <summary>
    /// Updates the current animation state.
    /// </summary>
    public void Update(GameTime gameTime)
    {
        // Debug.Log($"Direction: {_playerDirection}; State: {_playerState}");

        // Debug.Log($"Anim count: {animations.Count}");
        // foreach (Animation a in animations)
        // {
        //     Debug.Log($"Direction: {a._direction}, State: {a._state}");
        // }

        var found = _animations.TryGetValue((_playerState, _playerDirection), out var anim);
        if (found)
        {
            Debug.Log($"Direction: {anim._direction}, State: {anim._state}", DebugLevel.MEDIUM, DebugCategory.ANIMATIONHANDLER);
            anim.Update(gameTime);
        }
        else
        {
            Debug.Log($"anim obj nicht gefunden. Direction { _playerDirection}, State { _playerState }", DebugLevel.LOW, DebugCategory.ANIMATIONHANDLER);
        }

        // foreach (Animation anim in _animations)
        // {
        //     anim.Update(deltaTime);
        // }
    }

    /// <summary>
    /// Retrieves the source rectangle for the current animation frame.
    /// </summary>
    public Rectangle GetSubImage()
    {
        if (_animations.TryGetValue((_playerState, _playerDirection), out var anim))
        {
            return anim.getCurrentFrame();
        }
        return Rectangle.Empty;
    }

    /// <summary>
    /// Draws the animation frame for the given object.
    /// </summary>
    internal void Draw(GameHS gameHS, SpriteBatch spriteBatch, TextureObject obj)
    {
        Rectangle dest = new Rectangle(
            (int)obj._pos.X,
            (int)obj._pos.Y,
            _targetWidth > 0 ? _targetWidth : GetSubImage().Width,
            _targetHeight > 0 ? _targetHeight : GetSubImage().Height);
        spriteBatch.Draw(_spriteSheet, dest, GetSubImage(), Color.White);

        Debug.DrawPlayerPos(obj, gameHS, spriteBatch, DebugLevel.MEDIUM, DebugCategory.ANIMATIONHANDLER);
        Debug.DrawPlayerPosTop(obj, gameHS, spriteBatch, DebugLevel.HIGH, DebugCategory.ANIMATIONHANDLER);
    }

    /// <summary>
    /// Loads animation definitions from a JSON file.
    /// </summary>
    private void LoadJSON(string animationDataPath)
    {
        if (File.Exists(animationDataPath))
        {
            // JSON in JObject laden
            string jsonContent = File.ReadAllText(animationDataPath); // JSON-Datei als String laden
            JObject data = JObject.Parse(jsonContent); // In JObject umwandeln

            assetName = data["assetName"].ToString();

            // Durch das "animations"-Objekt iterieren
            if (data["animations"] is JObject jsonAnimations)
            {
                foreach (var jsonState in jsonAnimations)  // Animationsebene (IDLE, WALK, RUN, etc.)
                {
                    Debug.Log($"Animation: {jsonState.Key}", DebugLevel.MEDIUM, DebugCategory.ANIMATIONHANDLER);
                    PlayerState state = new PlayerState();
                    string sta = jsonState.Key;
                    switch (sta)
                    {
                        case "IDLE":
                            state = PlayerState.IDLE;
                            break;
                        case "WALK":
                            state = PlayerState.WALK;
                            break;
                        case "RUN":
                            state = PlayerState.RUN;
                            break;
                        case "JUMP":
                            state = PlayerState.JUMP;
                            break;
                        case "ATTACK":
                            state = PlayerState.ATTACK;
                            break;
                    }

                    if (jsonState.Value is JObject directions)
                    {
                        foreach (var jsonDirection in directions) // Richtungsebene (UP, DOWN, LEFT, RIGHT)
                        {
                            Debug.Log($"  Richtung: {jsonDirection.Key}", DebugLevel.MEDIUM, DebugCategory.ANIMATIONHANDLER);
                            PlayerDirection direction = new PlayerDirection();
                            string dir = jsonDirection.Key;
                            switch (dir)
                            {
                                case "UP":
                                    direction = PlayerDirection.UP;
                                    break;
                                case "DOWN":
                                    direction = PlayerDirection.DOWN;
                                    break;
                                case "LEFT":
                                    direction = PlayerDirection.LEFT;
                                    break;
                                case "RIGHT":
                                    direction = PlayerDirection.RIGHT;
                                    break;
                            }

                            if (jsonDirection.Value is JObject animationData)
                            {
                                Debug.Log($"    frameTime: {animationData["frameTime"]}", DebugLevel.MEDIUM, DebugCategory.ANIMATIONHANDLER);
                                int frameTime = int.Parse(animationData["frameTime"].ToString());

                                if (animationData["frames"] is JArray jsonFrames)
                                {
                                    List<Rectangle> animationFrames = new List<Rectangle>();
                                    foreach (var frame in jsonFrames) // Frame-Liste
                                    {
                                        Debug.Log($"    Frame: x={frame["x"]}, y={frame["y"]}, width={frame["width"]}, height={frame["height"]}", DebugLevel.HIGH, DebugCategory.ANIMATIONHANDLER);
                                        animationFrames.Add(new Rectangle(
                                            int.Parse(frame["x"].ToString()),
                                            int.Parse(frame["y"].ToString()),
                                            int.Parse(frame["width"].ToString()),
                                            int.Parse(frame["height"].ToString())));
                                    }
                                    _animations[(state, direction)] = new Animation(direction, state, animationFrames, frameTime);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

