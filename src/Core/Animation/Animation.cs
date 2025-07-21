/// <summary>
/// Represents a sprite animation sequence with timing and frame data.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using HackenSlay;
using HackenSlay.Core.Dev;

namespace HackenSlay.Core.Animation;

/// <summary>
/// Handles frame based animations for a specific direction and state.
/// </summary>
public class Animation
{
    public PlayerDirection _direction { get; set; }
    public PlayerState _state { get; set; }
    public List<Rectangle> _frames { get; set; }
    private int _frameTime;
    private int _elapsedTime;
    private int _currentFrame;

    /// <summary>
    /// Resets the animation to the first frame.
    /// </summary>
    internal void Reset()
    {
        _currentFrame = 0;
        _elapsedTime = 0;
    }

    /// <summary>
    /// Creates a new animation using the given frame list.
    /// </summary>
    public Animation(PlayerDirection direction, PlayerState state, List<Rectangle> frames, int frameTime)
    {
        _direction = direction;
        _state = state;
        _frames = frames;
        _frameTime = frameTime;
    }

    /// <summary>
    /// Returns the rectangle for the current frame.
    /// </summary>
    internal Rectangle getCurrentFrame()
    {
        return _frames[_currentFrame];
    }

    /// <summary>
    /// Advances the animation based on the elapsed time.
    /// </summary>
    internal void Update(GameTime gameTime)
    {
        _elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
        if (_elapsedTime >= _frameTime)
        {
            _currentFrame = (_currentFrame + 1) % _frames.Count;
            _elapsedTime = 0;
        }
        Debug.Log($"CurrentFrame: { _currentFrame}", DebugLevel.HIGH, DebugCategory.ANIMATIONHANDLER);
    }
}