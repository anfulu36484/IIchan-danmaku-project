using System;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    class Bullet2 :BulletBase
    {
        /*public Bullet2(Danmaku danmaku, Vector2f startPosition, Vector2f size, 
            float hitboxRadius, GameObject targetObject, GameObject ownerObject, EventHandler<EventArgs> onCollision, int lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, targetObject, ownerObject, onCollision, 
                  lifeTime,danmaku.Textures["bullet2"],new NoneDeterminantOfDirectionOfMovement(), )
        {
        }*/


        public Bullet2(Danmaku danmaku, Vector2f startPosition, GameObject targetObject,
            GameObject ownerObject, EventHandler<EventArgs> onCollision) 
            : base(danmaku, 
                  startPosition,
                  new Vector2f(30, 30),
                  10,
                  targetObject,
                  ownerObject,
                  onCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, 
                  new NoneRotator(), 
                  new NoneDeterminantOfDirectionOfMovement(), 
                  danmaku.Textures["bullet2"], 
                  new TurnIntoBonusWayOfDying(danmaku))
        {
        }
    }
}
