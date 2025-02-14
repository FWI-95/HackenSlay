using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackenSlay;

public class GameHS : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    List<TextureObject> _textureObjects;
    public UserInput userInput { get; }
    public SpriteFont _font;

    public GameHS()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _textureObjects = new List<TextureObject>();
        userInput = new UserInput(this);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _textureObjects.Add(new Player(this));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
        foreach (TextureObject obj in _textureObjects)
        {
            obj.LoadContent(this);
        }

        _font = Content.Load<SpriteFont>("fonts/Arial");
    }

    protected override void Update(GameTime gameTime)
    {
        if (userInput.Escape())
            Exit();

        // TODO: Add your update logic here
        foreach (TextureObject obj in _textureObjects)
        {
            obj.Update(this, gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        foreach (TextureObject obj in _textureObjects)
        {
            obj.Draw(this, _spriteBatch);
        }

        Debug.DrawScreenSize(this, _spriteBatch, _font);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
