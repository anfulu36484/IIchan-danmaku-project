﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects.Bullets;
using SFML.System;

namespace iichanTouhou.Attack
{
    class Attack2 :AttackBase
    {
        public Attack2(Danmaku danmaku, Vector2f startPoint, double lifeTime) : base(danmaku, startPoint, lifeTime)
        {
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
                    , new Vector2f(30, 30), 10, Danmaku.mainObject, OnCollision,double.PositiveInfinity);
                bullets[i].Initialize();

            }

        }

        double k=1000000;

        public override void Tick()
        {
            base.Tick();
            for (int i = 0; i < CountOfBullets; i++)
            {
                bullets[i].Tick();
                bullets[i].Position = GetStartOfPoint(fiArray[i]);
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
