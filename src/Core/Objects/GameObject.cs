// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework;
using HackenSlay.Core.Physics;

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

    /// <summary>
    /// Optional collider component for this object.
    /// </summary>
    public Collider? Collider { get; private set; }

    public Rectangle BoundingBox => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

    public GameObject()
    {
        Position = Vector2.Zero;
        Velocity = Vector2.Zero;
    }

    /// <summary>
    /// Attaches a collider to this object if none exists.
    /// </summary>
    public void AddCollider(bool isTrigger = false)
    {
        Collider ??= new Collider(this, isTrigger);
    }

    /// <summary>
    /// Removes the collider from this object.
    /// </summary>
    public void RemoveCollider()
    {
        Collider = null;
    }

    public virtual void LoadContent(GameHS game) { }

    public virtual void Update(GameHS game, GameTime gameTime)
    {
        if (!IsActive)
            return;
        Position += Velocity;
    }
}
