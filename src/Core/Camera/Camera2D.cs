using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay.World.Map;

public class Camera2D
{
    public Vector2 Position { get; private set; }

    public Matrix GetViewMatrix() => Matrix.CreateTranslation(new Vector3(-Position, 0));

    public void CenterOn(Vector2 target, Viewport viewport)
    {
        Position = target - new Vector2(viewport.Width / 2f, viewport.Height / 2f);
    }
}
