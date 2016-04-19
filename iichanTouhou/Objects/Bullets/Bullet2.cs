using System;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
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
            Texture = danmaku.Textures["bullet2"];
        }

    }
}
