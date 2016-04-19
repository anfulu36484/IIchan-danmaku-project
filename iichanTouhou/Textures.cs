using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;
using SFML.Graphics;

namespace iichanTouhou
{
    internal class Textures
    {
        private Texture GenerateTexture(Bitmap image, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return new Texture(ms);
        }

        private readonly Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public void Load()
        {
            _textures.Add("Bonus", GenerateTexture(Properties.Resources.Bonus, ImageFormat.Png));
            _textures.Add("npc", GenerateTexture(Properties.Resources.npc, ImageFormat.Png));

            _textures.Add("bullet1", GenerateTexture(Properties.Resources.bullet1, ImageFormat.Png));
            _textures.Add("bullet2", GenerateTexture(Properties.Resources.bullet2, ImageFormat.Png));
            _textures.Add("bullet3", GenerateTexture(Properties.Resources.bullet4, ImageFormat.Png));
        }

        public Texture this[string name] => _textures[name];
    }
}
