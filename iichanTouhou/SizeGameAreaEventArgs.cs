using System;
using SFML.System;

namespace iichanTouhou
{
    class SizeGameAreaEventArgs:EventArgs
    {
        public Vector2f ScaleFactor { get; set; }

        public SizeGameAreaEventArgs(Vector2f scaleFactor)
        {
            ScaleFactor = scaleFactor;
        }
    }
}