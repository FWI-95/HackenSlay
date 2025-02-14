using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.Xna.Framework.Graphics;

namespace HackenSlay;

public static class Debug
{
    static DebugLevel debugLevel = DebugLevel.INTERNAL;
    public static void Log(string msg)
    {
        if (debugLevel > DebugLevel.NONE)
        {
            Console.WriteLine(msg);
        }
    }

    public static void DrawPlayerPos(Player player, GameHS game, SpriteBatch spriteBatch)
    {
        if (debugLevel > DebugLevel.INTERNAL)
        {
            // spriteBatch.DrawString()
        }
    }
}

public enum DebugLevel 
{
    NONE, INTERNAL, EXTERNAL
}