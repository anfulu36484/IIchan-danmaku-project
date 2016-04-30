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
            : base(danmaku, startPosition, new Vector2f(50,50), 25, targetObjects, ownerObject, onCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, new InDirectionOfMotionRotator(),
                  new MovementToNearestTargetObject(),
                  danmaku.Textures["bulletmainobject3"])
        {
            
        }

        public override void Initialize()
        {
            DeterminantOfDirectionOfMovement.SpeedFactor = 10;
           
        }
    }
}
