using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Audio;

namespace HackenSlay.UI.Menus;

public class PauseMenu
{
    private bool _isPaused;
    private bool _prevState;
    private readonly AudioManager _audio = new();
    private bool _musicPlayed;

    public void LoadContent(GameHS game)
    {
        _audio.LoadSong(game.Content, "pauseMusic", "audio/pause_menu");
    }

    public void Update(GameHS game)
    {
        bool pressed = game.userInput.IsActionPressed("pause");
        if (pressed && !_prevState)
        {
            _isPaused = !_isPaused;
            if (_isPaused && !_musicPlayed)
            {
                _audio.PlaySong("pauseMusic");
                _musicPlayed = true;
            }
            else if (!_isPaused)
            {
                _audio.StopSong();
                _musicPlayed = false;
            }
        }
        _prevState = pressed;
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isPaused) return;
        spriteBatch.DrawString(game._font, "Paused", new Vector2(100, 150), Color.White);
    }
}
