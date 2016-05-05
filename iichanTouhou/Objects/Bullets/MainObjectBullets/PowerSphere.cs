using System.Collections.Generic;
using IIchanDanmakuProject.Attack.AttackOfMainObject;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    class PowerSphere :BulletBase
    {

        private AttackOfMainObject1 _attackOfMainObject1;

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

        public override void Initialize()
        {
            base.Initialize();
            _attackOfMainObject1 = new AttackOfMainObject1(Danmaku,this,CenterCoordinates,50,1);
            _attackOfMainObject1.Initialize();
        }

        public override void Update()
        {
            base.Update();
            _attackOfMainObject1.Update();
        }

        public override void Render()
        {
            base.Render();
            _attackOfMainObject1.Render();
        }
    }
}
