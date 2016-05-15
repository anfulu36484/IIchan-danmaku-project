using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.NPCBullets
{
    class BulletForDirectedAttack :BulletBase
    {
        public BulletForDirectedAttack(Danmaku danmaku, Vector2f startPosition, 
            List<GameObject> targetObjects,
            GameObject ownerObject, EventHandler<EventArgs> onCollision, 
            DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement) 
            : base(danmaku, startPosition, new Vector2f(50,50), 20, targetObjects, 
                  ownerObject, onCollision, int.MaxValue/danmaku.FrameRateLimit,
                  new AroundCenterRotator(10), determinantOfDirectionOfMovement,
                  danmaku.Textures["BulletForDirectedAttack"], new GoBeyondGameAreaWayOfDying(danmaku), 
                  new StatChanger(-1))
        {
        }
    }
}
