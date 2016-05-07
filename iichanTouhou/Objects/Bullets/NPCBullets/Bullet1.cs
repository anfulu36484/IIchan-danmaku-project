using System;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.NPCBullets
{
    class Bullet1:BulletBase
    {

        public Bullet1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, 
            GameObject targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision, int lifeTime) 
            : base(danmaku, startPosition, size, hitboxRadius, targetObjects, ownerObject, onCollision, lifeTime,new NoneRotator(), 
                  new MovementFromOwnerObject(),danmaku.Textures["bullet1"],new GoBeyondGameAreaWayOfDying(danmaku),
                  new StatChanger(-100))
        {

        }

    }
}
