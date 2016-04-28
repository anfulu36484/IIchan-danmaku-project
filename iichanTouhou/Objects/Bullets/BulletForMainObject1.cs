using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    class BulletForMainObject1 :BulletBase
    {
        public BulletForMainObject1(Danmaku danmaku, Vector2f startPosition, 
            List<GameObject> targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, new Vector2f(20,20), 10, targetObjects, ownerObject, onCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, new InDirectionOfMotionRotator(),
                  new MovementToNearestTargetObject(),
                  danmaku.Textures["bulletmainobject1"])
        {
        }

        public override void Initialize()
        {

        }
    }
}
