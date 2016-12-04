using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

static class Calculator
{
    public static Vector2 Normalize(Vector2 v)
    {
        float length = Length(v);
        return new Vector2(v.X / length, v.Y / length);
    }

    public static float Length(Vector2 v)
    {
        return (float)Math.Sqrt( v.X * v.X + v.Y * v.Y);
    }

    public static float Difference(Vector2 v1, Vector2 v2)
    {
        return Length( new Vector2( v1.X - v2.X, v1.Y - v2.Y ) );
    }

    
}

