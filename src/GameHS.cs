/// <summary>
/// Main entry point game class handling initialization and rendering.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HackenSlay.World.Map;
using HackenSlay.UI.Menus;
using HackenSlay.Core.Objects;
using HackenSlay.Core.Animation;
using HackenSlay.Core.Dev;

namespace HackenSlay;

/// <summary>
/// MonoGame implementation that bootstraps HackenSlay.
/// </summary>
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
    private HackenSlay.UI.Menus.InventoryMenu _inventoryMenu;
    private RenderTarget2D? _sceneTarget;
    public Vector2 MapSize { get; private set; }
    public TileType[,] MapTiles => _mapGenerator.Tiles;
    public int TileSize => _mapGenerator.TileSize;

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
        _inventoryMenu = new HackenSlay.UI.Menus.InventoryMenu();
        _camera = new Camera2D();
    }

    protected override void Initialize()
    {

        userInput.Initialize();

        player = new Player(this);
        _visualEngine.Add(player);

        // spawn a simple enemy for testing
        var enemy = DevSpawner.SpawnEnemy("dummy");
        enemy._pos = player._pos + new Vector2(100, 0);
        _visualEngine.Add(enemy);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _sceneTarget = new RenderTarget2D(GraphicsDevice,
            GraphicsDevice.PresentationParameters.BackBufferWidth,
            GraphicsDevice.PresentationParameters.BackBufferHeight);
        // create map after graphics device is ready
        _mapGenerator = new MapGenerator(GraphicsDevice, 50, 50, 64);
        _tileMap = WorldBuilder.Build(GraphicsDevice, _mapGenerator);
        MapSize = new Vector2(
            _mapGenerator.Width * _mapGenerator.TileSize,
            _mapGenerator.Height * _mapGenerator.TileSize);
        // TODO: use this.Content to load your game content here
        _visualEngine.LoadContent(this);
        player._pos = new Vector2(
            _mapGenerator.Width * _mapGenerator.TileSize / 2f,
            _mapGenerator.Height * _mapGenerator.TileSize / 2f);

        _devTool.LoadContent(this);
        _devConsole.LoadContent(this);
        _startMenu.LoadContent(this);
        _pauseMenu.LoadContent(this);
        _inventoryMenu.LoadContent(this);

        _font = Content.Load<SpriteFont>("fonts/Arial");
    }

    protected override void Update(GameTime gameTime)
    {
        if (userInput.IsActionPressed("dev_menu"))
            userInput.ReloadMappings();

        _startMenu.Update(this);
        _pauseMenu.Update(this, !_startMenu.IsActive && !_startMenu.JustClosed);
        if (!_startMenu.IsActive && !_pauseMenu.IsPaused)
            _inventoryMenu.Update(this);

        if (_startMenu.IsActive || _pauseMenu.IsPaused)
            return;

        _visualEngine.Update(this, gameTime);
        _camera.CenterOn(player._pos, GraphicsDevice.Viewport);

        _devTool.Update(this, gameTime);
        _devConsole.Update(this, gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (_sceneTarget == null)
        {
            base.Draw(gameTime);
            return;
        }

        GraphicsDevice.SetRenderTarget(_sceneTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
        _tileMap?.Draw(_spriteBatch);

        if (!_startMenu.IsActive)
        {
            _visualEngine.Draw(this, _spriteBatch);
        }
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        if (_pauseMenu.IsPaused)
        {
            _pauseMenu.Draw(this, _spriteBatch, _sceneTarget);
        }
        else
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_sceneTarget, Vector2.Zero, Color.White);
            _spriteBatch.End();
            _startMenu.Draw(this, _spriteBatch);
        }

        _spriteBatch.Begin();
        _devTool.Draw(this, _spriteBatch);
        _devConsole.Draw(this, _spriteBatch);
        _inventoryMenu.Draw(this, _spriteBatch);
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
