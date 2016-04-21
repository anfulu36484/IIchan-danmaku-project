using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Rotate
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
