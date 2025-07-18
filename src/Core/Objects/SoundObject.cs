// Erstellt mit Unterstützung von OpenAI Codex
using HackenSlay.Audio;

namespace HackenSlay.Core.Objects;

public class SoundObject : GameObject
{
    public AudioManager AudioManager { get; }

    public SoundObject()
    {
        AudioManager = new AudioManager();
    }
}
