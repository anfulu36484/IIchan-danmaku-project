using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace iichanTouhou.Objects.Bullets
{
    class Bullet1:GameObject
    {
        public Bullet1(Danmaku danmaku, int width, int height, Vector2f startPosition, float hitboxRadius) 
            : base(danmaku, width, height, startPosition, hitboxRadius)
        {
        }

        private Texture texture;
        private Sprite sprite;

        public override void LoadContent()
        {
        }

        public override void Initialize()
        {
            texture = TextureGenerator.Generate(Properties.Resources.bullet1, ImageFormat.Png);
            sprite = new Sprite(texture);
            sprite.Position = Position;
        }

        public override void Tick()
        {
            Position += Speed;
            sprite.Position = Position;
        }

        public override void Render()
        {
            danmaku.window.Draw(sprite);
        }

        
    }
}
