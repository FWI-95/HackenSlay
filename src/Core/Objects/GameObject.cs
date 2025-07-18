// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework;

namespace HackenSlay.Core.Objects;

public class GameObject
{
    public bool IsActive { get; set; } = true;
    public bool IsEnabled { get; set; } = true;
    public bool IsIntangible { get; set; }
    public bool IsMovable { get; set; } = true;

    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Size { get; set; } = new Vector2(1, 1);

    public Rectangle BoundingBox => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

    public GameObject()
    {
        Position = Vector2.Zero;
        Velocity = Vector2.Zero;
    }

    public virtual void LoadContent(GameHS game) { }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
        if (!IsActive)
            return;
        Position += Velocity;
    }
}
