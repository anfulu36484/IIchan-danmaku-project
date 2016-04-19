using System;
using SFML.System;

namespace IIchanDanmakuProject.Helpers
{
    public static class Vector
    {
        public static float Length(this Vector2f vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector2f Normalize(this Vector2f vector)
        {
            float length = vector.Length();
            return new Vector2f(vector.X/length,vector.Y/length);
        }
    }
}
