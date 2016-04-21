using System;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
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
                /*bullets[i] = new Bullet3(Danmaku, GetPosition(FiArray[i])
                    , new Vector2f(20, 20), 8, Danmaku.MainObject, OwnerObject, OnCollision,int.MaxValue/Danmaku.FrameRateLimit);*/
                bullets[i] = new Bulleto1(Danmaku, GetPosition(FiArray[i]), Danmaku.MainObject, OwnerObject, OnCollision);
                bullets[i].Initialize();
            }
        }

        private int ii = 1;

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < CountOfBullets; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Update();
                    bullets[i].Position = GetPosition(FiArray[i]);
                }
            }
            ii++;
            K += ii*5;
        }


        protected override Vector2f GetPosition(float fi)
        {
            double r = Math.Sin(Math.Log(fi * K))/ Math.Cos(fi / K);
            return ConvertToCartesianCoordinates(r, fi);
        }


        
    }
}
