using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;

namespace HackenSlay.Audio;

public class AudioManager
{
    private readonly Dictionary<string, SoundEffect> _soundEffects = new();
    private readonly Dictionary<string, Song> _songs = new();

    /// <summary>
    /// Loads a sound effect into the manager.
    /// </summary>
    public void LoadSound(ContentManager content, string name, string path)
    {
        try
        {
            _soundEffects[name] = content.Load<SoundEffect>(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load sound '{name}' from '{path}': {ex.Message}");
        }
    }

    /// <summary>
    /// Loads a music track into the manager.
    /// </summary>
    public void LoadSong(ContentManager content, string name, string path)
    {
        try
        {
            _songs[name] = content.Load<Song>(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load song '{name}' from '{path}': {ex.Message}");
        }
    }

    /// <summary>
    /// Play a sound effect by name.
    /// </summary>
    public void PlaySound(string name)
    {
        if (_soundEffects.TryGetValue(name, out var s))
        {
            s.Play();
        }
    }

    /// <summary>
    /// Play a song by name. Optionally loop.
    /// </summary>
    public void PlaySong(string name, bool repeat = true)
    {
        if (_songs.TryGetValue(name, out var song))
        {
            MediaPlayer.IsRepeating = repeat;
            MediaPlayer.Play(song);
        }
    }

    /// <summary>
    /// Stops any currently playing music.
    /// </summary>
    public void StopSong()
    {
        MediaPlayer.Stop();
    }
}
