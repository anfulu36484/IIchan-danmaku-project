using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate
{
    abstract class RotatorBase
    {
        protected BulletBase Bullet;

        public virtual void Initialize(BulletBase bullet)
        {
            Bullet = bullet;
        }

        public abstract void Rotate();
    }

}
