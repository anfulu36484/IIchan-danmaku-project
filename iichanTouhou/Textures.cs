using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SFML.Graphics;

namespace IIchanDanmakuProject
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

            _textures.Add("hitbox", GenerateTexture(Properties.Resources.hitbox, ImageFormat.Png));

            _textures.Add("bullet11", GenerateTexture(Properties.Resources.hitbox, ImageFormat.Png));

            _textures.Add("bulleto1", new Texture(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Resources\bulleto1.png"));

            _textures.Add("bulletmainobject3", new Texture(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Resources\bulletmainobject3.png"));

            _textures.Add("powersphere", new Texture(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Resources\powersphere.png"));
            _textures.Add("greencirno", new Texture(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Resources\greencirno.png"));
        }

        public Texture this[string name] => _textures[name];
    }
}
