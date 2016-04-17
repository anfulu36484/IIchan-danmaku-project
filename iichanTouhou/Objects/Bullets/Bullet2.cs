using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;
using SFML.System;

namespace iichanTouhou.Objects.Bullets
{
    class Bullet2 :BulletBase
    {
        public Bullet2(Danmaku danmaku, Vector2f startPosition, Vector2f size, 
            float hitboxRadius, GameObject targetObject, GameObject ownerObject, EventHandler<EventArgs> onCollision, int lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, targetObject, ownerObject, onCollision, lifeTime)
        {
        }

        public override void Initialize()
        {
            Texture = TextureGenerator.Generate(Properties.Resources.bullet2, ImageFormat.Png);
        }

    }
}
