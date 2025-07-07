using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

public class DummyItem : Item
{
    public DummyItem() : base(null)
    {
        _name = "DummyItem";
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void Draw(SpriteBatch spriteBatch, Player player)
    {
    }

    public override void Handle(GameHS game)
    {
    }
}
