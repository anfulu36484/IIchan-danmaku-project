using System;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.PolarAttack
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
                BulletBase bullet =new Bullet2(Danmaku, GetPosition(FiArray[i]), Danmaku.MainObject, OwnerObject, OnCollision);
                Bullets.Add(bullet);
            }
        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < CountOfBullets; i++)
            {
                if (Bullets[i] != null)
                {
                    Bullets[i].Update();
                    Bullets[i].Position = GetPosition(FiArray[i]);
                }
            }
            K += 0.000007f;
        }

        protected  Vector2f GetPosition(float fi)
        {
            double r = Math.Cos((Math.Sin(fi*K) + Math.Cos(fi*K)))/Math.Cos(fi*fi/K);
            return ConvertToWindowCoordinates(r, fi);
        }

    }
}
