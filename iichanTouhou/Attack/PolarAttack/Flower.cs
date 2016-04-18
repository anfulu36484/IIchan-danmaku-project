using System;
using iichanTouhou.Objects;
using iichanTouhou.Objects.Bullets;
using SFML.System;

namespace iichanTouhou.Attack.PolarAttack
{
    class Flower :PolarAttackBase
    {
        public Flower(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint) 
            : base(danmaku, ownerObject, startPoint, 10, 100, 1500, 1000000)
        {
        }


        public override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < CountOfBullets; i++)
            {
                bullets[i] = new Bullet2(Danmaku, GetPosition(FiArray[i])
                    , new Vector2f(30, 30), 10, Danmaku.MainObject, OwnerObject, OnCollision,int.MaxValue/Danmaku.FrameRateLimit);
                bullets[i].Initialize();
            }
        }

        protected override Vector2f GetPosition(float fi)
        {
            double r = Math.Cos((Math.Sin(fi*K) + Math.Cos(fi*K)))/Math.Cos(fi*fi/K);
            return ConvertToCartesianCoordinates(r, fi);
        }

    }
}
