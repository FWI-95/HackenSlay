using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay;

public class TextureObject
{
    public Vector2 _pos { get; set; }
    public Texture2D _sprite { get; set; }
    public SpriteFont _font;
    public AnimationHandler animationHandler;
    public Vector2 _velocity;
    public string _name { get; set; }
    public int _health { get; set; }
    public int _strength { get; set; }
    public string _animationdata { get; set; }
    public float _walkspeed;
    public float _runspeed;

    public TextureObject(GameHS Game)
    {
        _pos = new Vector2(0, 0);
        _velocity = new Vector2(0, 0);

        animationHandler = new AnimationHandler();
    }

    public virtual void LoadContent(GameHS game)
    {
        _sprite = game.Content.Load<Texture2D>("sprites/missing");
        _font = game.Content.Load<SpriteFont>("fonts/Arial");
    }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
        Vector2 newPos = _pos + _velocity;

        if (newPos.X + animationHandler.getSubImage().Width > game.Window.ClientBounds.Width
            || newPos.X < 0)
        {
            _velocity.X = 0;
        }

        if (newPos.Y + animationHandler.getSubImage().Height > game.Window.ClientBounds.Height
            || newPos.Y < 0)
        {
            _velocity.Y = 0;
        }

        _pos += _velocity;

        Debug.Log($"{_name} pos: {_pos}", DebugLevel.HIGH, DebugCategory.PLAYERCALC);
    }

    public virtual void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, _pos, Color.White);
    }

    // public Texture2D getImage()
    // {
    //     return _sprite.
    // }
}