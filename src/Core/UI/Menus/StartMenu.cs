using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Audio;

namespace HackenSlay.UI.Menus;

public class StartMenu
{
    private bool _active = true;
    private readonly AudioManager _audio = new();

    public bool IsActive => _active;

    public void LoadContent(GameHS game)
    {
        // Example path: "audio/start_music"
        _audio.LoadSong(game.Content, "start", "audio/start_music");
    }

    public void Update(GameHS game)
    {
        if (_active && game.userInput.IsActionPressed("pause"))
        {
            _active = false;
            _audio.StopSong();
        }
        else if (_active)
        {
            _audio.PlaySong("start");
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_active) return;
        spriteBatch.DrawString(game._font, "Start Screen - Press Escape", new Vector2(100, 100), Color.White);
    }
}
