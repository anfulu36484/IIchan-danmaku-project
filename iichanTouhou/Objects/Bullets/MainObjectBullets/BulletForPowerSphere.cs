using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    class BulletForPowerSphere :BulletBase
    {
        public BulletForPowerSphere(Danmaku danmaku, Vector2f startPosition, 
            List<GameObject> targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, new Vector2f(50,50), 25, targetObjects, ownerObject, onCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, 
                  new InDirectionOfMotionRotator(),
                  new MovementToNearestTargetObject(new MovementFromObject(danmaku.MainObject,new Vector2f(0,130))), 
                  danmaku.Textures["bulletmainobject3"],
                  new NoneWayOfDying(danmaku),new StatChanger(-1))
        {
            
        }

        public override void Initialize()
        {
            DeterminantOfDirectionOfMovement.SpeedFactor = 10;
            DeterminantOfDirectionOfMovement.Initialize(this);
        }
    }
}
