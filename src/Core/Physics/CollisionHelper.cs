// Erstellt mit Unterstützung von OpenAI Codex
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HackenSlay.Core.Objects;

namespace HackenSlay.Core.Physics;

public static class CollisionHelper
{
    public static Vector2 ResolveMovement(
        TextureObject mover,
        IEnumerable<TextureObject> objects)
    {
        Vector2 newPos = mover._pos + mover._velocity;
        Rectangle newRect = new Rectangle(
            (int)newPos.X,
            (int)newPos.Y,
            (int)mover.Size.X,
            (int)mover.Size.Y);
        foreach (var obj in objects)
        {
            if (ReferenceEquals(obj, mover) || !obj._isActive || obj.IsIntangible)
                continue;

            Rectangle other = new Rectangle(
                (int)obj._pos.X,
                (int)obj._pos.Y,
                (int)obj.Size.X,
                (int)obj.Size.Y);
            if (newRect.Intersects(other))
                return mover._pos;
        }

        return newPos;
    }
}
