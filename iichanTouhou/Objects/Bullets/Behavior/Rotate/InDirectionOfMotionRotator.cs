using System;
using IIchanDanmakuProject.Helpers;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate
{
    class InDirectionOfMotionRotator :RotatorBase
    {

        Vector2f _previousPosition = new Vector2f(0,0);


        public override void Rotate()
        {
            Vector2f direction = Bullet.CenterCoordinates - _previousPosition;
            Bullet.RectangleShape.Rotation = MathConverter.RadianToDegrees( Math.Atan(direction.Y/direction.X));
           _previousPosition = Bullet.CenterCoordinates;
        }
    }
}
