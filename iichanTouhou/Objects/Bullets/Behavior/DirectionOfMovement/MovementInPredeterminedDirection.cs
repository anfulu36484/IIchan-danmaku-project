using IIchanDanmakuProject.Helpers;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    class MovementInPredeterminedDirection :DeterminantOfDirectionOfMovementBase
    {
        private Vector2f _direction;

        public MovementInPredeterminedDirection(Vector2f direction)
        {
            _direction = direction;  
        }

        public override void Move()
        {
            Bullet.Speed = _direction.Normalize() * SpeedFactor;
        }
    }
}
