using HackenSlay;
using Microsoft.Xna.Framework;
using Xunit;

namespace HackenSlay.Tests;

public class FoodTests
{
    [Fact]
    public void HandleRestoresHealthAndRemovesFromInventory()
    {
        var player = new Player(null);
        player.Inventory.Add(new DummyItem()); // ensure inventory not empty
        int start = player._health;
        var bread = new Bread(player);
        player.Inventory.Add(bread);

        bread.Handle(null);

        Assert.Equal(start + bread.HealAmount, player._health);
        Assert.DoesNotContain(bread, player.Inventory.Items);
    }

    [Fact]
    public void UpdateAddsFoodToInventoryOnCollision()
    {
        var player = new Player(null);
        player.Size = new Vector2(10, 10);
        player._pos = Vector2.Zero;
        var apple = new Apple(player)
        {
            Size = new Vector2(10, 10),
            _pos = Vector2.Zero
        };

        apple.Update(null, new GameTime());

        Assert.Contains(apple, player.Inventory.Items);
        Assert.False(apple._isActive);
        Assert.False(apple._isVisible);
    }
}
