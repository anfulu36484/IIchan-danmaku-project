namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate
{
    class AroundCenterRotator :RotatorBase
    {
        public float AngleOfRotation = 10;

        
        public AroundCenterRotator()
        {
            
        }

        public AroundCenterRotator(float angleOfRotation)
        {
            AngleOfRotation = angleOfRotation;
        }

        public override void Rotate()
        {
            Bullet.RotatorContainer.Rotation += AngleOfRotation;
        }
    }
}
