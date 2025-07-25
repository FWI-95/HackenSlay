/// <summary>
/// Maintains and renders all visual game objects.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;
using HackenSlay.Core.Physics;

namespace HackenSlay.Core.Animation;

/// <summary>
/// Manages a collection of drawable texture objects.
/// </summary>
public class VisualEngine
{
    private readonly List<TextureObject> _objects = new();
    private readonly List<Collider> _colliders = new();

    public IReadOnlyList<TextureObject> Objects => _objects;
    public IReadOnlyList<Collider> Colliders => _colliders;

    /// <summary>
    /// Registers a drawable object with the engine.
    /// </summary>
    public void Add(TextureObject obj)
    {
        if (!_objects.Contains(obj))
        {
            _objects.Add(obj);
            if (obj.Collider != null && !_colliders.Contains(obj.Collider))
                _colliders.Add(obj.Collider);
        }
    }

    /// <summary>
    /// Removes an object from the engine.
    /// </summary>
    public void Remove(TextureObject obj)
    {
        _objects.Remove(obj);
        if (obj.Collider != null)
            _colliders.Remove(obj.Collider);
    }

    /// <summary>
    /// Loads content for all registered objects.
    /// </summary>
    public void LoadContent(GameHS game)
    {
        foreach (var obj in _objects)
        {
            obj.LoadContent(game);
        }
    }

    /// <summary>
    /// Updates all managed objects.
    /// </summary>
    public void Update(GameHS game, GameTime gameTime)
    {
        foreach (var obj in _objects)
        {
            obj.Update(game, gameTime);
        }
    }

    /// <summary>
    /// Draws all managed objects.
    /// </summary>
    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        foreach (var obj in _objects)
        {
            obj.Draw(game, spriteBatch);
        }
    }
}
