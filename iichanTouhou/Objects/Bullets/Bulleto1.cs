using System;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    class Bulleto1:BulletBase
    {
        public Bulleto1(Danmaku danmaku, Vector2f startPosition,  GameObject targetObject, GameObject ownerObject, 
            EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, new Vector2f(40,40), 5, targetObject, ownerObject, onCollision,
                  int.MaxValue/danmaku.FrameRateLimit, new InDirectionOfMotionRotator(), new NoneDeterminantOfDirectionOfMovement()
                  , danmaku.Textures["bulleto1"])
        {
        }

    }
}
