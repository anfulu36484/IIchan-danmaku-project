namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate
{
    class AroundCenterRotator :RotatorBase
    {
        public float AngleOfRotation = 10;

        public override void Rotate()
        {
            Bullet.RectangleShape.Rotation += AngleOfRotation;
        }
    }
}
