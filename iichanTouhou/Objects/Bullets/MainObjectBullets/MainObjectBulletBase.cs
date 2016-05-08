using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects.Bullets.MainObjectBullets
{
    abstract class MainObjectBulletBase:BulletBase
    {

        private DeterminantOfDirectionOfMovementBase _focusedMovement;
        private DeterminantOfDirectionOfMovementBase _anfocusedMovement;

        protected MainObjectBulletBase(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, 
            List<GameObject> targetObjects, GameObject ownerObject, EventHandler<EventArgs> onCollision,  RotatorBase rotator, DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement, 
            Texture texture) 
            : base(danmaku, startPosition, size, hitboxRadius, targetObjects, 
                  ownerObject, onCollision, int.MaxValue / danmaku.FrameRateLimit, rotator, determinantOfDirectionOfMovement, 
                  texture, new NoneWayOfDying(danmaku), new StatChanger(-1))
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
            _focusedMovement = new MovementToNearestTargetObject(new MovementInPredeterminedDirection(new Vector2f(0, -1)));
            _focusedMovement.SpeedFactor = _anfocusedMovement.SpeedFactor;
            _focusedMovement.Initialize(this);
        }
    }
}
