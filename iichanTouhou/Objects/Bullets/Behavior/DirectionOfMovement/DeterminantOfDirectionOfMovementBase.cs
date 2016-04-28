namespace IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement
{
    abstract class DeterminantOfDirectionOfMovementBase
    {
        protected BulletBase Bullet;

        public float SpeedFactor = 1.5f;

        public virtual void Initialize(BulletBase bullet)
        {
            Bullet = bullet;
        }

        public abstract void Move();

    }
}
