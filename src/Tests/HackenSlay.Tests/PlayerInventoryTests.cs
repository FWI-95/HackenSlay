using HackenSlay;
using Xunit;

namespace HackenSlay.Tests;

public class PlayerInventoryTests
{
    private class DummyWeaponItem : Weapon
    {
        public DummyWeaponItem() : base(1,1,1) {}
        public override void Update(GameHS game, Microsoft.Xna.Framework.GameTime gameTime) {}
        public override void Draw(GameHS game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {}
        public override void Use(Microsoft.Xna.Framework.Vector2 p, Microsoft.Xna.Framework.Vector2 d, Player pl, Microsoft.Xna.Framework.Vector2 t) {}
    }

    [Fact]
    public void DropItemRemovesFromInventory()
    {
        var player = new Player(null);
        var item = new DummyItem();
        player.Inventory.Add(item);
        player.DropItem(null, item);
        Assert.DoesNotContain(item, player.Inventory.Items);
        Assert.True(item._isActive);
        Assert.True(item._isVisible);
    }
}
