using SFML.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


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
