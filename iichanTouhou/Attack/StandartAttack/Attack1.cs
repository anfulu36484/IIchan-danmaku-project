using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.NPCBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.StandartAttack
{
    class Attack1 : AttackBase
    {

        public Attack1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime)
            : base(danmaku, ownerObject, startPoint, lifeTime, 50)
        {
        }

        public override void Initialize()
        {

            Bullets = new List<BulletBase>(CountOfBullets);
            float fi = 10;
            for (int i = 0; i < CountOfBullets; i++)
            {
                BulletBase bullet = new Bullet1(Danmaku, GetStartPosition(fi),new Vector2f(50,50),25, Danmaku.MainObject,OwnerObject,
                    OnCollision,int.MaxValue/Danmaku.FrameRateLimit);

                bullet.Initialize();
                Bullets.Add(bullet);

                fi += 10f;
            }
        }

        protected Vector2f GetStartPosition(float fi)
        {
            return new Vector2f((float)(fi * Math.Sin(fi) + StartPoint.X), (float)(fi * Math.Cos(fi) + StartPoint.Y));
        }



        public override void Update()
        {
            base.Update();
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i] != null)
                {
                    Bullets[i].Update();
                    if (!Bullets[i].IsObjectInGameArea())
                        Bullets[i] = null;
                }
            }
        }


        
    }
}
