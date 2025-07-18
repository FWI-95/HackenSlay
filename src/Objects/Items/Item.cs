using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;

namespace HackenSlay
{
    public abstract class Item : TextureObject
    {
        

        protected Item() : base()
        {
        }

        public abstract override void Update(GameHS game, GameTime gameTime);
        public abstract override void Draw(GameHS game, SpriteBatch spriteBatch);
        public abstract void Handle(GameHS game);
    }
}