using HackenSlay.Core.Player;
using Xunit;

namespace HackenSlay.Tests;

public class InventoryTests
{
    private class TestItem : Item
    {
        public TestItem() { _isActive = true; _isVisible = true; }
        public override void Update(GameHS game, Microsoft.Xna.Framework.GameTime gameTime) { }
        public override void Draw(GameHS game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) { }
        public override void Handle(GameHS game) { }
    }

    [Fact]
    public void MoveItemChangesOrder()
    {
        var inv = new Inventory();
        var a = new TestItem();
        var b = new TestItem();
        var c = new TestItem();
        inv.Add(a);
        inv.Add(b);
        inv.Add(c);
        inv.MoveItem(0, 2);
        Assert.Equal(a, inv.Items[2]);
    }
}
