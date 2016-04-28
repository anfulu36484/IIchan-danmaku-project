using System;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class Bonus :BulletBase
    {
        public Bonus(Danmaku danmaku, Vector2f startPosition,GameObject targetObject,
            GameObject ownerObject, EventHandler<EventArgs> onCollision)
        : base(danmaku, startPosition, new Vector2f(5,5),2, targetObject, ownerObject, 
              onCollision, int.MaxValue/danmaku.FrameRateLimit,new NoneRotator(), new MovementToNearestTargetObject())
        {
            DeterminantOfDirectionOfMovement.SpeedFactor = 5;

            Texture = danmaku.Textures["Bonus"];
            Collision += Bonus_Collision;
        }

        private int _bonusPoint = 10;

        private void Bonus_Collision(object sender, EventArgs e)
        {
            Danmaku.MainObject.Score += _bonusPoint;
        }

        public override void Initialize()
        {

        }

    }
}
