using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    class BulletForMainObject1 :BulletBase
    {
        public BulletForMainObject1(Danmaku danmaku, Vector2f startPosition, 
            List<GameObject> targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, new Vector2f(20,20), 10, targetObjects, ownerObject, onCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, new InDirectionOfMotionRotator())
        {
        }

        public override void Initialize()
        {
            Texture = danmaku.Textures["bulletmainobject1"];
        }
    }
}
