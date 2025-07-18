using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

public class DummyItem : Item
{
    public DummyItem() : base()
    {
        _name = "DummyItem";
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
    }

    public override void Handle(GameHS game)
    {
    }
}
