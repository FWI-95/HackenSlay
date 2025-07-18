// Erstellt mit Unterstützung von OpenAI Codex
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Animation;

namespace HackenSlay.Core.Objects;

public class AnimationObject : TextureObject
{
    public AnimationHandler AnimationHandler { get; }

    public AnimationObject()
    {
        AnimationHandler = new AnimationHandler();
    }

    public override void LoadContent(GameHS game)
    {
        base.LoadContent(game);
    }

    public override void Update(GameHS game, GameTime gameTime)
    {
        base.Update(game, gameTime);
        AnimationHandler.Update(gameTime);
    }

    public override void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible || !_isActive)
            return;
        AnimationHandler.Draw(game, spriteBatch, this);
    }
}
