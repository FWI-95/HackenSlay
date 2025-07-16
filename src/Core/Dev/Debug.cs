/// <summary>
/// Provides helper methods for debugging output and overlays.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay.Core.Objects;

namespace HackenSlay.Core.Dev;

/// <summary>
/// Utility class for logging messages and drawing debug information.
/// </summary>
public static class Debug
{
    static DebugLevel currentDebugLevel = DebugLevel.ALL;
    static Dictionary<DebugCategory, Boolean> categoryActive = new Dictionary<DebugCategory, bool>()
    {
        { DebugCategory.VISUAL, false},
        { DebugCategory.ANIMATIONHANDLER, false},
        { DebugCategory.DRAWING, false},
        { DebugCategory.PLAYERCALC, false},
        { DebugCategory.USERINPUT, true},
        { DebugCategory.WEAPON, true},
        { DebugCategory.ITEM, true},
        { DebugCategory.ENEMY, true}
    };

    /// <summary>
    /// Writes a debug message if the specified level and category are enabled.
    /// </summary>
    public static void Log(string msg, DebugLevel debugLevel, DebugCategory debugCategory)
    {
        if (debugLevel <= currentDebugLevel)
        {
            if (categoryActive[debugCategory])
            {
                Console.WriteLine(msg);
            }
        }
    }

    public static void DrawPlayerPos(TextureObject obj, GameHS game, SpriteBatch spriteBatch, DebugLevel debugLevel, DebugCategory debugCategory)
    {
        if (debugLevel <= currentDebugLevel)
        {
            if (categoryActive[debugCategory])
            {
                spriteBatch.DrawString(obj._font, obj._pos.ToString(), obj._pos, Color.Black);

                Vector2 bounds = new Vector2(
                    (obj._pos.X + obj.animationHandler.GetSubImage().Width),
                    (obj._pos.Y + obj.animationHandler.GetSubImage().Height));
                spriteBatch.DrawString(obj._font, bounds.ToString(), bounds, Color.Red);
            }

        }
    }

    public static void DrawPlayerPosTop(TextureObject obj, GameHS game, SpriteBatch spriteBatch, DebugLevel debugLevel, DebugCategory debugCategory)
    {
        if (debugLevel <= currentDebugLevel)
        {
            if (categoryActive[debugCategory])
            {
                Vector2 bounds = new Vector2(0,10);
                spriteBatch.DrawString(obj._font, obj._pos.ToString(), bounds, Color.Black);

                bounds = new Vector2(0,20);
                spriteBatch.DrawString(obj._font, bounds.ToString(), bounds, Color.Red);
            }

        }
    }

    public static void DrawScreenSize(GameHS game, SpriteBatch spriteBatch, SpriteFont font)
    {
        spriteBatch.DrawString(font, game.Window.ClientBounds.ToString(), new Vector2(0,0), Color.White);
    }

}

public enum DebugLevel
{
    NONE, LOW, MEDIUM, HIGH, ALL
}

public enum DebugCategory
{
    VISUAL, ANIMATIONHANDLER, DRAWING, PLAYERCALC, USERINPUT, WEAPON, ITEM, ENEMY
}