using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Audio;

namespace HackenSlay.UI.Menus;

public class StartMenu : IDisposable
{
    private bool _active = true;
    private readonly AudioManager _audio = new();
    private bool _musicPlayed;
    private Texture2D? _pixel;
    private bool _disposed;
    private bool _justClosed;

    public bool IsActive => _active;
    public bool JustClosed => _justClosed;

    public void LoadContent(GameHS game)
    {
        _audio.LoadSong(game.Content, "startMusic", "audio/start_menu");
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
    }

    public void Update(GameHS game)
    {
        _justClosed = false;
        if (_active && !_musicPlayed)
        {
            _audio.PlaySong("startMusic");
            _musicPlayed = true;
        }

        if (_active && game.userInput.IsActionPressed("pause"))
        {
            _active = false;
            _audio.StopSong();
            Dispose();
            _justClosed = true;
        }
        else if (_active)
        {
            _audio.PlaySong("start");
            _musicPlayed = false;
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_active || _pixel == null) return;
        int width = game.GraphicsDevice.PresentationParameters.BackBufferWidth;
        int height = game.GraphicsDevice.PresentationParameters.BackBufferHeight;

        // spriteBatch.Begin();
        spriteBatch.Draw(_pixel, new Rectangle(0, 0, width, height), Color.Black * 0.3f);
        spriteBatch.DrawString(game._font, "Start Screen - Press Escape", new Vector2(100, 100), Color.White);
        // spriteBatch.End();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _pixel?.Dispose();
        _pixel = null;
        _disposed = true;
    }
}
