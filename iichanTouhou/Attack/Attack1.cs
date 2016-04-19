using System;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack
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
                bullets[i] =new Bullet1(Danmaku, GetPosition(fi),new Vector2f(50,50),25, Danmaku.MainObject,OwnerObject,
                    OnCollision,int.MaxValue/Danmaku.FrameRateLimit);
                bullets[i].Initialize();
                bullets[i].Speed = (bullets[i].Position - StartPoint).Normalize()*1.5f;
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
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Update();
                    if (!bullets[i].IsObjectInGameArea())
                        bullets[i] = null;
                }
            }
        }


        public Attack1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime, int countOfBulletsForEasyMode) 
            : base(danmaku, ownerObject, startPoint, lifeTime, countOfBulletsForEasyMode)
        {
        }
    }
}
