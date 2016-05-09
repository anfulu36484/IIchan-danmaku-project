using System;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class StarBonus :BulletBase
    {
        public StarBonus(Danmaku danmaku, Vector2f startPosition,GameObject targetObject,
            GameObject ownerObject, EventHandler<EventArgs> onCollision)
        : base(danmaku, startPosition, new Vector2f(10,10),5, targetObject, ownerObject, 
              onCollision, int.MaxValue/danmaku.FrameRateLimit,new AroundCenterRotator(90), new MovementToNearestTargetObject(new Vector2f(0,1)),
              danmaku.Textures["starbonus"],new NoneWayOfDying(danmaku),new StatChanger(0,0,10))
        {
            DeterminantOfDirectionOfMovement.SpeedFactor = 5;

        }
    }
}
