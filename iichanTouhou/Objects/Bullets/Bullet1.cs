using System;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
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
