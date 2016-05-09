using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class TenBonus :BulletBase
    {
        private DeterminantOfDirectionOfMovementBase _defaultOfDirectionOfMovement;
        private DeterminantOfDirectionOfMovementBase _movementToNearestTargetObject;


        public TenBonus(Danmaku danmaku, Vector2f startPosition) 
            : base(danmaku, startPosition, new Vector2f(35,35), 17, danmaku.MainObject,
                  danmaku.SliceOfLifeBase.Shinigami,
                  danmaku.SliceOfLifeBase.Shinigami.OnCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, 
                  new NoneRotator(),
                  new MovementInPredeterminedDirection(new Vector2f(0,1)), 
                  danmaku.Textures["TenBonus"],
                  new NoneWayOfDying(danmaku),
                  new StatChanger(0,0,100))
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            RectangleShape.FillColor = new Color(255, 255, 255, 200);
            DeterminantOfDirectionOfMovement.SpeedFactor = 3;

            _defaultOfDirectionOfMovement = DeterminantOfDirectionOfMovement;
            _movementToNearestTargetObject =new MovementToNearestTargetObject(new Vector2f(0,-1));
            _movementToNearestTargetObject.Initialize(this);
        }

        public override void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) & 
                (
                    (this.CenterCoordinates - this.TargetObjects[0].CenterCoordinates).Length()<120
                    ||
                    this.TargetObjects[0].CenterCoordinates.Y<200
                ))
            {
                DeterminantOfDirectionOfMovement = _movementToNearestTargetObject;
                DeterminantOfDirectionOfMovement.SpeedFactor = 10;
            }
            else if ((this.CenterCoordinates - this.TargetObjects[0].CenterCoordinates).Length() < 60)
            {
                DeterminantOfDirectionOfMovement = _movementToNearestTargetObject;
                DeterminantOfDirectionOfMovement.SpeedFactor = 5;
            }
            else
            {
                DeterminantOfDirectionOfMovement = _defaultOfDirectionOfMovement;
                
            }

            base.Update();
        }
    }
}
