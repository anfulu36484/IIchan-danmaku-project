using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Rotate
{
    abstract class RotatorBase
    {
        protected BulletBase Bullet;

        public void AddBullet(BulletBase bullet)
        {
            Bullet = bullet;
            Bullet.RectangleShape.Origin = new Vector2f(Bullet.Size.X * 0.5f, Bullet.Size.Y * 0.5f);
        }

        public abstract void Rotate();
    }

}
