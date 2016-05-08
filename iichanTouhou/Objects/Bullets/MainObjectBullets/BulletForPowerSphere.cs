using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    class BulletForPowerSphere :BulletBase
    {
        private DeterminantOfDirectionOfMovementBase _focusedMovement;
        private DeterminantOfDirectionOfMovementBase _anfocusedMovement;

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

        public override void Update()
        {
            base.Update();
            DeterminantOfDirectionOfMovement = Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? _focusedMovement : _anfocusedMovement;
        }

        public override void Initialize()
        {
            DeterminantOfDirectionOfMovement.SpeedFactor = 10;
            DeterminantOfDirectionOfMovement.Initialize(this);
            _anfocusedMovement = DeterminantOfDirectionOfMovement;
            _focusedMovement = new MovementToNearestTargetObject(new MovementInPredeterminedDirection(new Vector2f(0,-1)));
            _focusedMovement.SpeedFactor = _anfocusedMovement.SpeedFactor;
            _focusedMovement.Initialize(this);
        }

    }
}
