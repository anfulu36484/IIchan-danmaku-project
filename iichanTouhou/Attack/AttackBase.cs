using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects.Bullets;
using SFML.System;

namespace iichanTouhou.Attack
{
    abstract class AttackBase :GameBase
    {
        protected readonly Danmaku Danmaku;
        protected readonly Vector2f StartPoint;

        protected BulletBase[] bullets;

        protected readonly int countOfBullets = 100;
        
        protected AttackBase(Danmaku danmaku, Vector2f startPoint)
        {
            Danmaku = danmaku;
            StartPoint = startPoint;
        }

        protected abstract Vector2f GetStartOfPoint(float fi, float r);


        public void OnCollision(object obj, EventArgs e)
        {
            Console.WriteLine(@"Столкновение произошло");
        }

        public override void Render()
        {
            foreach (var bullet in bullets)
            {
                bullet?.Render();
            }
        }
    }
}
