using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HackenSlay.World.Map;
using HackenSlay.UI.Menus;

namespace HackenSlay;

public class GameHS : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private VisualEngine _visualEngine;
    private DevConsole _devConsole;
    public IEnumerable<TextureObject> Objects => _visualEngine.Objects;
    public UserInput userInput { get; }
    public SpriteFont _font;
    public Player player { get; private set; }
    private MapGenerator _mapGenerator;
    private TileMap _tileMap;
    private Camera2D _camera;
    private DevOverlay _devTool;
    private HackenSlay.UI.Menus.StartMenu _startMenu;
    private HackenSlay.UI.Menus.PauseMenu _pauseMenu;

    public GameHS()
    {
        _graphics = new GraphicsDeviceManager(this);
        // Setup up the default resolution for the project
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        Debug.Log("ScreenPrefWidth: " + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + "; ScreenPrefHeight: " + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, DebugLevel.HIGH, DebugCategory.VISUAL);

        // Runs the game in "full Screen" mode using the set resolution
        _graphics.IsFullScreen = true;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _visualEngine = new VisualEngine();
        userInput = new UserInput(this);
        _devTool = new DevOverlay();
        _devConsole = new DevConsole();
        _startMenu = new HackenSlay.UI.Menus.StartMenu();
        _pauseMenu = new HackenSlay.UI.Menus.PauseMenu();
        _camera = new Camera2D();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        userInput.Initialize();

        player = new Player(this);
        _visualEngine.Add(player);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // create map after graphics device is ready
        _mapGenerator = new MapGenerator(GraphicsDevice, 50, 50, 64);
        _tileMap = WorldBuilder.Build(GraphicsDevice, _mapGenerator);
        // TODO: use this.Content to load your game content here
        _visualEngine.LoadContent(this);

        _devTool.LoadContent(this);
        _devConsole.LoadContent(this);

        _font = Content.Load<SpriteFont>("fonts/Arial");
    }

    protected override void Update(GameTime gameTime)
    {
        if (userInput.IsActionPressed("dev_menu"))
            userInput.ReloadMappings();

        _startMenu.Update(this);
        _pauseMenu.Update(this);

        if (_startMenu.IsActive)
            return;

        // TODO: Add your update logic here
        _visualEngine.Update(this, gameTime);

        _camera.CenterOn(player._pos, GraphicsDevice.Viewport);

        _devTool.Update(this, gameTime);
        _devConsole.Update(this, gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
        _tileMap?.Draw(_spriteBatch);

        if (!_startMenu.IsActive)
        {
            _visualEngine.Draw(this, _spriteBatch);
        }

        _startMenu.Draw(this, _spriteBatch);
        _pauseMenu.Draw(this, _spriteBatch);

        _devTool.Draw(this, _spriteBatch);
        _devConsole.Draw(this, _spriteBatch);

        Debug.DrawScreenSize(this, _spriteBatch, _font);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void AddObject(TextureObject obj)
    {
        _visualEngine.Add(obj);
        obj.LoadContent(this);
    }
}
