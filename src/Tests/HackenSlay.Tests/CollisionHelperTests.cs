using HackenSlay.Core.Objects;
using HackenSlay.Core.Physics;
using Microsoft.Xna.Framework;
using Xunit;

namespace HackenSlay.Tests;

public class CollisionHelperTests
{
    [Fact]
    public void MovementIsBlockedByObstacle()
    {
        var mover = new TextureObject();
        mover.Size = new Vector2(10, 10);
        mover._pos = Vector2.Zero;
        mover._velocity = new Vector2(10, 0);

        var obstacle = new TextureObject();
        obstacle.Size = new Vector2(10, 10);
        obstacle._pos = new Vector2(5, 0);
        obstacle.IsIntangible = false;

        Vector2 result = CollisionHelper.ResolveMovement(mover, new[] { mover, obstacle });
        Assert.Equal(Vector2.Zero, result);
    }
}
