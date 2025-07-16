using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Audio;

namespace HackenSlay.UI.Menus;

public class PauseMenu
{
    private bool _isPaused;
    private bool _prevState;
    private readonly AudioManager _audio = new();

    public void LoadContent(GameHS game)
    {
        _audio.LoadSong(game.Content, "pause", "audio/pause_music");
    }

    public void Update(GameHS game)
    {
        bool pressed = game.userInput.IsActionPressed("pause");
        if (pressed && !_prevState)
        {
            _isPaused = !_isPaused;
            if (_isPaused)
            {
                _audio.PlaySong("pause");
            }
            else
            {
                _audio.StopSong();
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
