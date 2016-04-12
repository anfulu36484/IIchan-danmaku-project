using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iichanTouhou.Objects.Bullets;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Attack
{
    class Attack1 : AttackBase
    {


        public Attack1(Danmaku danmaku, Vector2f startPoint) : base(danmaku, startPoint)
        {
        }

        public override void LoadContent()
        {
            
        }

        public override void Initialize()
        {
            bullets = new Bullet1[countOfBullets];
            float fi = 10;
            for (int i = 0; i < countOfBullets; i++)
            {
                bullets[i] =new Bullet1(Danmaku, GetStartOfPoint(fi, fi),new Vector2f(50,50),25, Danmaku.mainObject,OnCollision);
                bullets[i].Initialize();
                bullets[i].Speed = (bullets[i].Position - StartPoint)*0.005f;
                fi += 10f;
            }
        }

        protected override Vector2f GetStartOfPoint(float fi, float r)
        {
            return new Vector2f((float)(r * Math.Sin(fi) + StartPoint.X), (float)(r * Math.Cos(fi) + StartPoint.Y));
        }



        public override void Tick()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Tick();
                    if (!bullets[i].IsObjectInGameArea())
                        bullets[i] = null;
                }
            }
        }

        
    }
}
