using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    class BulletForMainAttack:MainObjectBulletBase
    {
        public BulletForMainAttack(Danmaku danmaku, Vector2f startPosition,
            List<GameObject> targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision
            ) 
            : base(danmaku, startPosition, new Vector2f(50, 50), 25, targetObjects, 
                  ownerObject, onCollision, new InDirectionOfMotionRotator(),
                  new MovementToNearestTargetObject(new MovementFromObject(danmaku.MainObject, new Vector2f(0, 130))),
                  danmaku.Textures["mainattack"])
        {
        }
    }
}
