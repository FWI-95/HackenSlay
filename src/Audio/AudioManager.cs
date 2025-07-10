using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace HackenSlay.Audio;

public class AudioManager
{
    private readonly Dictionary<string, SoundEffect> _sounds = new();

    public void Load(ContentManager content, string name, string path)
    {
        _sounds[name] = content.Load<SoundEffect>(path);
    }

    public void Play(string name)
    {
        if (_sounds.TryGetValue(name, out var s))
            s.Play();
    }
}
