using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIchanDanmakuProject.Helpers
{
    static class MathConverter
    {
        public static float RadianToDegrees(float radian)
        {
            return radian*180/(float)Math.PI;
        }

        public static float RadianToDegrees(double radian)
        {
            return (float)(radian * 180 / Math.PI);
        }
    }
}
