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
    class Bullet1:BulletBase
    {
        public Bullet1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, 
            GameObject targetObject, EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, size, hitboxRadius, targetObject, onCollision)
        {
        }

        
        public override void LoadContent()
        {
        }

        public override void Initialize()
        {
            Texture = TextureGenerator.Generate(Properties.Resources.bullet1, ImageFormat.Png);
        }

        public override void Tick()
        {
            base.Tick();
            Position += Speed;
        }

    }
}
