using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace HackenSlay;

public class Animation
{
    public Direction _direction { get; set; }
    public State _state { get; set; }
    public List<Rectangle> _frames { get; set; }
    private int _frameTime;
    private int _elapsedTime;
    private int _currentFrame;

    public Animation(Direction direction, State state, List<Rectangle> frames, int frameTime)
    {
        _direction = direction;
        _state = state;
        _frames = frames;
        _frameTime = frameTime;
    }

    internal Rectangle getCurrentFrame()
    {
        return _frames[_currentFrame];
    }

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