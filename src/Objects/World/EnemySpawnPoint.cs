using Microsoft.Xna.Framework;

namespace HackenSlay.World;

public class EnemySpawnPoint
{
    public Vector2 Position { get; }
    private bool _alarm;

    public EnemySpawnPoint(Vector2 pos)
    {
        Position = pos;
    }

    public void TriggerAlarm()
    {
        _alarm = true;
    }

    public bool ShouldSpawn() => _alarm;
}
