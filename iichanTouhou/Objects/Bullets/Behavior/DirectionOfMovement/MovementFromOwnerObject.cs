using IIchanDanmakuProject.Helpers;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementFromOwnerObject:DeterminantOfDirectionOfMovementBase
    {


        public override void Move()
        {
            Bullet.Speed = (Bullet.CenterCoordinates - Bullet.OwnerObject.CenterCoordinates).Normalize() * SpeedFactor;
        }
    }
}
