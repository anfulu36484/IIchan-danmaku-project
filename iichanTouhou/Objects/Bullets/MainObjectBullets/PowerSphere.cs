using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    class PowerSphere :BulletBase
    {
        public PowerSphere(Danmaku danmaku, Vector2f startPosition,
            List<GameObject> targetObjects, GameObject ownerObject)
            : base(danmaku, 
                  startPosition,
                  new Vector2f(40,40), 
                  20,
                  targetObjects, 
                  ownerObject, 
                  null, 
                  int.MaxValue/danmaku.FrameRateLimit,
                  new AroundCenterRotator(), 
                  new NoneDeterminantOfDirectionOfMovement(), 
                  danmaku.Textures["powersphere"], 
                  new NoneWayOfDying(danmaku), 
                  new StatChanger(0,0,0))
        {
            Texture.Smooth = true;
        }

    }
}
