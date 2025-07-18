using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Audio;
using HackenSlay.UI.Elements;

namespace HackenSlay.UI.Menus;

public class StartMenu : IDisposable
{
    private bool _active = true;
    private readonly AudioManager _audio = new();
    private bool _musicPlayed;
    private List<SimpleButton> _buttons = new();
    private SimpleButton? _backButton;
    private bool _showSettings;
    private Texture2D? _pixel;
    private RenderTarget2D? _blurTarget;
    private bool _disposed;
    private bool _justClosed;

    public bool IsActive => _active;
    public bool JustClosed => _justClosed;

    public void LoadContent(GameHS game)
    {
        _audio.LoadSong(game.Content, "startMusic", "audio/start_menu");
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        int width = 200;
        int height = 50;
        int centerX = game.Window.ClientBounds.Width / 2 - width / 2;
        int startY = game.Window.ClientBounds.Height / 2 - (height * 3 + 20) / 2;

        _buttons = new List<SimpleButton>
        {
            new SimpleButton(game, new Rectangle(centerX, startY, width, height), "Starten", () =>
            {
                _active = false;
                _audio.StopSong();
                _musicPlayed = false;
                Dispose();
                _justClosed = true;
            }),
            new SimpleButton(game, new Rectangle(centerX, startY + height + 10, width, height), "Einstellungen", () =>
            {
                _showSettings = true;
            }),
            new SimpleButton(game, new Rectangle(centerX, startY + (height + 10) * 2, width, height), "Beenden", () =>
            {
                game.Exit();
            })
        };

        _backButton = new SimpleButton(game, new Rectangle(centerX, startY + (height + 10) * 2, width, height), "Zurück", () =>
        {
            _showSettings = false;
        });
    }

    public void Update(GameHS game)
    {
        _justClosed = false;
        if (!_active)
            return;

        if (!_musicPlayed)
        {
            _audio.PlaySong("startMusic");
            _musicPlayed = true;
        }

        if (game.userInput.IsActionPressed("pause"))
        {
            _active = false;
            _audio.StopSong();
            _musicPlayed = false;
            Dispose();
            _justClosed = true;
            return;
        }

        if (_showSettings)
        {
            _backButton?.Update();
        }
        else
        {
            foreach (var btn in _buttons)
            {
                btn.Update();
            }
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch, Texture2D scene)
    {
        if (!_active || _pixel == null) return;

        int width = game.GraphicsDevice.PresentationParameters.BackBufferWidth;
        int height = game.GraphicsDevice.PresentationParameters.BackBufferHeight;

        if (_blurTarget == null || _blurTarget.Width != width / 4 || _blurTarget.Height != height / 4)
        {
            _blurTarget?.Dispose();
            _blurTarget = new RenderTarget2D(game.GraphicsDevice, width / 4, height / 4);
        }

        game.GraphicsDevice.SetRenderTarget(_blurTarget);
        game.GraphicsDevice.Clear(Color.Transparent);
        spriteBatch.Begin(samplerState: SamplerState.LinearClamp);
        spriteBatch.Draw(scene, new Rectangle(0, 0, _blurTarget.Width, _blurTarget.Height), Color.White);
        spriteBatch.End();
        game.GraphicsDevice.SetRenderTarget(null);

        spriteBatch.Begin(samplerState: SamplerState.LinearClamp);
        spriteBatch.Draw(_blurTarget, new Rectangle(0, 0, width, height), Color.White);
        spriteBatch.End();

        spriteBatch.Begin();
        spriteBatch.Draw(_pixel, new Rectangle(0, 0, width, height), Color.Black * 0.3f);

        if (_showSettings)
        {
            spriteBatch.DrawString(game._font, "Einstellungen", new Vector2(width / 2 - 60, height / 2 - 100), Color.White);
            _backButton?.Draw(spriteBatch);
        }
        else
        {
            foreach (var btn in _buttons)
            {
                btn.Draw(spriteBatch);
            }
        }

        spriteBatch.End();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _pixel?.Dispose();
        _blurTarget?.Dispose();
        _pixel = null;
        _disposed = true;
    }
}
