// Erstellt mit Unterstützung von OpenAI Codex
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HackenSlay.Core.Objects;

namespace HackenSlay.Core.Physics;

public static class CollisionHelper
{
    public static Vector2 ResolveMovement(
        TextureObject mover,
        IEnumerable<Collider> colliders)
    {
        Vector2 newPos = mover._pos + mover._velocity;
        Rectangle newRect = new Rectangle(
            (int)newPos.X,
            (int)newPos.Y,
            (int)mover.Size.X,
            (int)mover.Size.Y);
        foreach (var col in colliders)
        {
            var obj = col.Owner;
            if (ReferenceEquals(obj, mover) || !obj.IsActive || obj.IsIntangible)
                continue;
            if (newRect.Intersects(col.Bounds))
                return mover._pos;
        }

        return newPos;
    }
}
