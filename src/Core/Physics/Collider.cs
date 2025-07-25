// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework;
using HackenSlay.Core.Objects;

namespace HackenSlay.Core.Physics;

/// <summary>
/// Simple collider component attached to a <see cref="GameObject"/>.
/// </summary>
public class Collider
{
    /// <summary>Owner of this collider.</summary>
    public GameObject Owner { get; }

    /// <summary>Whether this collider is used only for trigger events.</summary>
    public bool IsTrigger { get; set; }

    /// <summary>Creates a new collider for the given owner.</summary>
    public Collider(GameObject owner, bool isTrigger = false)
    {
        Owner = owner;
        IsTrigger = isTrigger;
    }

    /// <summary>Gets the collider bounds in world space.</summary>
    public Rectangle Bounds => Owner.BoundingBox;
}
