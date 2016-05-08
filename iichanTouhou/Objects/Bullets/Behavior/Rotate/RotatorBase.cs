using System.Drawing;
using SFML.Graphics;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate
{
    abstract class RotatorBase
    {
        protected BulletBase Bullet;

        public virtual void Initialize(BulletBase bullet)
        {
            Bullet = bullet;
            Bullet.RotatorContainer.CreateRotatedRectangle();
        }

        public abstract void Rotate();
    }

}
