using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Schema;
using Microsoft.SqlServer.Server;
using SFML.System;

namespace iichanTouhou.Helpers
{
    static class TextureGenerator
    {
        public static Texture Generate(Bitmap image, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return new Texture(ms);
        }
    }

    public static class Vector
    {
        public static float Length(this Vector2f vector)
        {
            return (float)Math.Sqrt(vector.X*vector.X + vector.Y*vector.Y);
        }
    }
}
