﻿using System;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.NPCBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.PolarAttack
{
    class Flower2 :PolarAttackBase
    {
        public Flower2(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint) 
            : base(danmaku, ownerObject, startPoint,40, 1000, 1000, 1000000)
        {
        }


        public override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < CountOfBullets; i++)
            {
                BulletBase bullet = new Bulleto1(Danmaku, GetPosition(FiArray[i]), Danmaku.MainObject, OwnerObject, OnCollision);
                bullet.Initialize();

                Bullets.Add(bullet);
            }
        }

        private int ii = 1;

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i] != null)
                {
                    Bullets[i].Update();
                    Bullets[i].CenterCoordinates = GetPosition(FiArray[i]);
                }
            }
            ii++;
            K += ii*5;
        }


        protected Vector2f GetPosition(float fi)
        {
            double r = Math.Sin(Math.Log(fi * K))/ Math.Cos(fi / K);
            return ConvertToWindowCoordinates(r, fi);

        }

    }
}
