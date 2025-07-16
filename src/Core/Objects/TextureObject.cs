//Todo: Add a comment to the top of this file explaining what this file is for and what it does.
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HackenSlay.Core.Animation;
using HackenSlay.Audio;
using HackenSlay.Core.Dev;

namespace HackenSlay.Core.Objects;

public class TextureObject
{
    public Boolean _isActive { get; set; }
    public Boolean _isVisible { get; set; }
    public Vector2 _pos { get; set; }
    public Texture2D _sprite { get; set; }
    public SpriteFont _font;
    public AnimationHandler animationHandler;
    public AudioManager AudioManager { get; }
    public Vector2 _velocity;
    public string _name { get; set; }
    public int _health { get; set; }
    public int _strength { get; set; }
    public string _animationdata { get; set; }
    public float _walkspeed;
    public float _runspeed;

    public TextureObject()
    {
        _pos = new Vector2(0, 0);
        _velocity = new Vector2(0, 0);

        animationHandler = new AnimationHandler();
        AudioManager = new AudioManager();
    }

    public virtual void LoadContent(GameHS game)
    {
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
        _font = game.Content.Load<SpriteFont>("fonts/Arial");
    }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
        if (!_isActive)
            return;

        Vector2 newPos = _pos + _velocity;

        if (newPos.X + animationHandler.GetSubImage().Width > game.Window.ClientBounds.Width
            || newPos.X < 0)
        {
            _velocity.X = 0;
        }

        if (newPos.Y + animationHandler.GetSubImage().Height > game.Window.ClientBounds.Height
            || newPos.Y < 0)
        {
            _velocity.Y = 0;
        }

        _pos += _velocity;

        Debug.Log($"{_name} pos: {_pos}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
    }

    public virtual void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible)
            return;
        if (!_isActive)
            return;

            
        spriteBatch.Draw(_sprite, _pos, Color.White);
    }

    // public Texture2D getImage()
    // {
    //     return _sprite.
    // }
}