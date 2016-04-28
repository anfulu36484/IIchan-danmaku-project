using IIchanDanmakuProject.Helpers;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementFromStartPoint:DeterminantOfDirectionOfMovementBase
    {

        public override void Initialize(BulletBase bullet)
        {
            base.Initialize(bullet);
            Bullet.Speed = (Bullet.Position - Bullet.OwnerObject.CenterCoordinates).Normalize() * SpeedFactor;
        }

        public override void Move()
        {
        }
    }
}
