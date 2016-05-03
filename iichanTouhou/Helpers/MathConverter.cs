using System;
using SFML.System;

namespace IIchanDanmakuProject.Helpers
{
    public static class MathConverter
    {
        public static float RadianToDegrees(float radian)
        {
            return radian*180/(float)Math.PI;
        }

        public static float RadianToDegrees(double radian)
        {
            return (float)(radian * 180 / Math.PI);
        }

        public static float DegreesToRadian(double degrees)
        {
            return (float) ((degrees/180)*Math.PI);
        }



        public static PolarVector CartesianToPolarCoordinate(this Vector2f coordinate)
        {

            double r = Math.Pow((Math.Pow(coordinate.X, 2) + Math.Pow(coordinate.Y, 2)), 0.5);
            double theta = Math.Atan(coordinate.Y / coordinate.X) * 360 / 2 / Math.PI;
            if (coordinate.X >= 0 && coordinate.Y >= 0) {}
            else if (coordinate.X < 0 && coordinate.Y >= 0)
            {
                theta = 180 + theta;
            }
            else if (coordinate.X < 0 && coordinate.Y < 0)
            {
                theta = 180 + theta;
            }
            else if (coordinate.X > 0 && coordinate.Y < 0)
            {
                theta = 360 + theta;
            }

            return new PolarVector((float)(r),(float)theta);

           /* PolarVector polarVector = new PolarVector();
            polarVector.r = coordinate.Length();
            polarVector.theta = RadianToDegrees(Math.Atan(coordinate.Y/coordinate.X));
            return polarVector;*/
        }

        public static Vector2f PolarToCartesianCoordinate(this PolarVector coordinate)
        {
            /*var x = coordinate.r * Math.Cos(coordinate.theta * 2 * Math.PI / 360);
            var y = coordinate.r * Math.Sin(coordinate.theta * 2 * Math.PI / 360);

            return new Vector2f((float)x,(float)y);*/
            return new Vector2f((float)(coordinate.r * Math.Cos(DegreesToRadian(coordinate.theta)) ), 
                (float)(coordinate.r * Math.Sin(DegreesToRadian(coordinate.theta))));
        }

    }
}
