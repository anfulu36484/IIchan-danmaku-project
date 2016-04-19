using System;
using IIchanDanmakuProject.Helpers;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class Bonus :BulletBase
    {
        public Bonus(Danmaku danmaku, Vector2f startPosition,GameObject targetObject,
            GameObject ownerObject, EventHandler<EventArgs> onCollision)
        : base(danmaku, startPosition, new Vector2f(5,5),2, targetObject, ownerObject, onCollision, int.MaxValue/danmaku.FrameRateLimit)
        {
            Texture = danmaku.Textures["Bonus"];
        }


        public override void Initialize()
        {

        }

        private float _speedFactor = 5;

        public override void Update()
        {
            Speed = (TargetObjects[0].CenterCoordinates - CenterCoordinates).Normalize()*_speedFactor;
            base.Update();
        }

        
    }
}
