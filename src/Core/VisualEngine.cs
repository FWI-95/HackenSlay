//Todo: Add a comment to the top of this file explaining what this file is for and what it does.
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

public class VisualEngine
{
    private readonly List<TextureObject> _objects = new();

    public IReadOnlyList<TextureObject> Objects => _objects;

    public void Add(TextureObject obj)
    {
        if (!_objects.Contains(obj))
        {
            _objects.Add(obj);
        }
    }

    public void Remove(TextureObject obj)
    {
        _objects.Remove(obj);
    }

    public void LoadContent(GameHS game)
    {
        foreach (var obj in _objects)
        {
            obj.LoadContent(game);
        }
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        foreach (var obj in _objects)
        {
            obj.Update(game, gameTime);
        }
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        foreach (var obj in _objects)
        {
            obj.Draw(game, spriteBatch);
        }
    }
}
