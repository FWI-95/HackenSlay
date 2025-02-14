using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
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
        { DebugCategory.PLAYERCALC, false}
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

    public static void DrawPlayerPos(Player player, GameHS game, SpriteBatch spriteBatch, DebugLevel debugLevel, DebugCategory debugCategory)
    {
        if (debugLevel <= currentDebugLevel)
        {
            if (categoryActive[debugCategory])
            {
                // spriteBatch.DrawString()
            }

        }
    }
}

public enum DebugLevel
{
    NONE, LOW, MID, HIGH, ALL
}

public enum DebugCategory
{
    VISUAL, ANIMATIONHANDLER, DRAWING, PLAYERCALC
}