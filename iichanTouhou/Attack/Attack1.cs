using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iichanTouhou.Objects;
using iichanTouhou.Objects.Bullets;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Attack
{
    class Attack1 : AttackBase
    {





        public override void Initialize()
        {
            CountOfBullets = 50;

            bullets = new Bullet1[CountOfBullets];
            float fi = 10;
            for (int i = 0; i < CountOfBullets; i++)
            {
                bullets[i] =new Bullet1(Danmaku, GetStartOfPoint(fi),new Vector2f(50,50),25, Danmaku.mainObject,OwnerObject, OnCollision,double.PositiveInfinity);
                bullets[i].Initialize();
                bullets[i].Speed = (bullets[i].Position - StartPoint)*0.005f;
                fi += 10f;
            }
        }

        protected override Vector2f GetStartOfPoint(float fi)
        {
            return new Vector2f((float)(fi * Math.Sin(fi) + StartPoint.X), (float)(fi * Math.Cos(fi) + StartPoint.Y));
        }



        public override void Tick()
        {
            base.Tick();
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


        public Attack1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, double lifeTime) : base(danmaku, ownerObject, startPoint, lifeTime)
        {
        }
    }
}
