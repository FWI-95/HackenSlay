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

namespace HackenSlay;

public class AnimationHandler
{
    Texture2D _spriteSheet;
    List<Animation> animations;
    public Direction _playerDirection { get; set; }
    public State _playerState { get; set; }
    public string assetName { get; set; }
    public AnimationHandler()
    {
        animations = new List<Animation>();
    }

    public void LoadContent(GameHS game, string animationData)
    {
        LoadJSON(animationData);

        _spriteSheet = game.Content.Load<Texture2D>(assetName);
    }

    public void Update(GameTime gameTime)
    {
        // Debug.Log($"Direction: {_playerDirection}; State: {_playerState}");

        // Debug.Log($"Anim count: {animations.Count}");
        // foreach (Animation a in animations)
        // {
        //     Debug.Log($"Direction: {a._direction}, State: {a._state}");
        // }

        Animation anim = animations.Where(i => i._direction == _playerDirection && i._state == _playerState).FirstOrDefault();
        if (anim != null)
        {
            Debug.Log($"Direction: {anim._direction}, State: {anim._state}", DebugLevel.MID, DebugCategory.ANIMATIONHANDLER);
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

    public Rectangle getSubImage()
    {
        Animation anim = animations.Where(i => i._direction == _playerDirection && i._state == _playerState).FirstOrDefault();

        return anim.getCurrentFrame();
    }

    internal void Draw(GameHS gameHS, SpriteBatch spriteBatch, TextureObject obj)
    {
        spriteBatch.Draw(_spriteSheet, obj._pos, getSubImage(), Color.White);
    }

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
                    Debug.Log($"Animation: {jsonState.Key}", DebugLevel.MID, DebugCategory.ANIMATIONHANDLER);
                    State state = new State();
                    string sta = jsonState.Key;
                    switch (sta)
                    {
                        case "IDLE":
                            state = State.IDLE;
                            break;
                        case "WALK":
                            state = State.WALK;
                            break;
                        case "RUN":
                            state = State.RUN;
                            break;
                        case "JUMP":
                            state = State.JUMP;
                            break;
                        case "ATTACK":
                            state = State.ATTACK;
                            break;
                    }

                    if (jsonState.Value is JObject directions)
                    {
                        foreach (var jsonDirection in directions) // Richtungsebene (UP, DOWN, LEFT, RIGHT)
                        {
                            Debug.Log($"  Richtung: {jsonDirection.Key}", DebugLevel.MID, DebugCategory.ANIMATIONHANDLER);
                            Direction direction = new Direction();
                            string dir = jsonDirection.Key;
                            switch (dir)
                            {
                                case "UP":
                                    direction = Direction.UP;
                                    break;
                                case "DOWN":
                                    direction = Direction.DOWN;
                                    break;
                                case "LEFT":
                                    direction = Direction.LEFT;
                                    break;
                                case "RIGHT":
                                    direction = Direction.RIGHT;
                                    break;
                            }

                            if (jsonDirection.Value is JObject animationData)
                            {
                                Debug.Log($"    frameTime: {animationData["frameTime"]}", DebugLevel.MID, DebugCategory.ANIMATIONHANDLER);
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
                                    animations.Add(new Animation(direction, state, animationFrames, frameTime));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

