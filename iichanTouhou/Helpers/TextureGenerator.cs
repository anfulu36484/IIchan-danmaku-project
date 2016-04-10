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
using Microsoft.SqlServer.Server;

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
}
