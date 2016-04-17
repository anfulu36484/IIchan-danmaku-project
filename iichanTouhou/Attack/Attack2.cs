using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects;
using iichanTouhou.Objects.Bullets;
using SFML.System;

namespace iichanTouhou.Attack
{
    class Attack2 :AttackBase
    {
        public Attack2(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint) 
            : base(danmaku, ownerObject, startPoint,60*1)
        {
            Died += Attack2_Died;
        }

        private int o = 1;

        private void Attack2_Died(object sender, EventArgs e)
        {
            if(o==1)
            for (int i = 0; i < bullets.Length; i++)
            {
                Danmaku.sliceOfLife.Shinigami.AddAsBonus(bullets[i]);
                bullets[i] = null;
            }
            o = 2;
        }

        private float[] fiArray;



        public override void Initialize()
        {
            CountOfBullets = 600;

            fiArray = new float[CountOfBullets];
            for (int i = 0; i < CountOfBullets; i++)
            {
                fiArray[i] = i;
            }

            bullets = new Bullet2[CountOfBullets];

            for (int i = 0; i < CountOfBullets; i++)
            {
                bullets[i] = new Bullet2(Danmaku, GetStartOfPoint(fiArray[i])
                    , new Vector2f(30, 30), 10, Danmaku.mainObject, OwnerObject, OnCollision,double.PositiveInfinity);
                bullets[i].Initialize();

            }

        }

        double k=1000000;

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < CountOfBullets; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Update();
                    bullets[i].Position = GetStartOfPoint(fiArray[i]);
                }
            }
            k += 0.000007f;
        }

        private float attackScale = 1500;


        protected override Vector2f GetStartOfPoint(float fi)
        {
            double r = Math.Cos((Math.Sin(fi*k) + Math.Cos(fi*k)))/Math.Cos(fi*fi/k);

            return new Vector2f((float)(r*Math.Cos(fi)* attackScale + StartPoint.X),(float)(r*Math.Sin(fi))* attackScale + StartPoint.Y);
        }


        
    }
}
