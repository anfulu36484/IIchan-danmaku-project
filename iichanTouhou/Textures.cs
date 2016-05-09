using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using SFML.Graphics;

namespace IIchanDanmakuProject
{
    internal class Textures
    {
        public byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        private readonly Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public void Load()
        {
            ResourceManager rm = Properties.Resources.ResourceManager;

            ResourceSet rs = rm.GetResourceSet(new CultureInfo("en-US"), true, true);

            if (rs == null) return;
            foreach (var entry in rs.Cast<DictionaryEntry>().Where(n=>n.Value is System.Drawing.Image))
            {
                _textures.Add(entry.Key.ToString(),new Texture(ImageToByte((System.Drawing.Image)entry.Value)));
            }
        }

        public Texture this[string name] => _textures[name];
    }
}
