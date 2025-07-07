using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay
{
    public abstract class Item : TextureObject
    {
        

        protected Item() : base()
        {
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, Player player);
        public abstract void Handle(GameHS game);
    }
}