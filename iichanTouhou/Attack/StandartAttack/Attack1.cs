using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.StandartAttack
{
    class Attack1 : AttackBase
    {

        public override void Initialize()
        {
            CountOfBullets = 50;

            Bullets = new List<BulletBase>(CountOfBullets);
            float fi = 10;
            for (int i = 0; i < CountOfBullets; i++)
            {
                BulletBase bullet = new Bullet1(Danmaku, GetPosition(fi),new Vector2f(50,50),25, Danmaku.MainObject,OwnerObject,
                    OnCollision,int.MaxValue/Danmaku.FrameRateLimit);

                bullet.Initialize();
                //bullet.Speed =  (Bullets[i].Position - StartPoint).Normalize()*1.5f;

                Bullets.Add(bullet);

                fi += 10f;
            }
        }

        protected override Vector2f GetPosition(float fi)
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


        public Attack1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime, int countOfBulletsForEasyMode) 
            : base(danmaku, ownerObject, startPoint, lifeTime, countOfBulletsForEasyMode)
        {
        }
    }
}
