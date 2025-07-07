using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

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
        { DebugCategory.ITEM, false }
    };

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
                    (obj._pos.X + obj.animationHandler.getSubImage().Width), 
                    (obj._pos.Y + obj.animationHandler.getSubImage().Height));
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
    VISUAL, ANIMATIONHANDLER, DRAWING, PLAYERCALC, USERINPUT, WEAPON, ITEM
}