using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace HackenSlay.Audio;

public class AudioManager
{
    private readonly Dictionary<string, SoundEffect> _soundEffects = new();
    private readonly Dictionary<string, Song> _songs = new();
    public void LoadSoundEffect(ContentManager content, string name, string path)
    {
        _soundEffects[name] = content.Load<SoundEffect>(path);
    }

    public void LoadSong(ContentManager content, string name, string path)
    {
        _songs[name] = content.Load<Song>(path);
    }

    public void PlaySoundEffect(string name)
    {
        if (_soundEffects.TryGetValue(name, out var effect))
            effect.Play();
    }

    public void PlaySong(string name, bool isRepeating = true)
    {
        if (_songs.TryGetValue(name, out var song))
        {
            MediaPlayer.IsRepeating = isRepeating;
            MediaPlayer.Play(song);
        }
    }

    public void StopSong()
    {
        if (MediaPlayer.State != MediaState.Stopped)
            MediaPlayer.Stop();
    }
}
