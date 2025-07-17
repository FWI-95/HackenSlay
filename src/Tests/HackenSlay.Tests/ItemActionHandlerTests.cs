using HackenSlay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Xunit;
using HackenSlay.Core.Objects;

namespace HackenSlay.Tests;

public class ItemActionHandlerTests
{
    private class TestItem : Item
    {
        public bool Handled { get; private set; }
        public TestItem()
        {
            _isActive = true;
        }
        public override void Update(GameTime gameTime) { }
        public override void Draw(SpriteBatch spriteBatch, Player player) { }
        public override void Handle(GameHS game) { Handled = true; }
    }

    [Fact]
    public void PrimaryAttackInvokesHandle()
    {
        var handler = new ItemActionHandler(null, null);
        var item = new TestItem();
        handler.Collect(null, item);
        handler.PrimaryAttack(null);
        Assert.False(item._isActive);
        Assert.True(item.Handled);
    }
}
