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
            GameObject targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision, int lifeTime) 
            : base(danmaku, startPosition, size, hitboxRadius, targetObjects, ownerObject, onCollision, lifeTime)
        {

        }

        public override void Initialize()
        {
            Texture = danmaku.Textures["bullet1"];
        }

    }
}
