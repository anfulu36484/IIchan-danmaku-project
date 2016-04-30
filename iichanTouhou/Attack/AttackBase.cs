using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack
{
    abstract class AttackBase :GameElement
    {
        protected readonly GameObject OwnerObject;

        protected readonly Vector2f StartPoint;

        protected List<BulletBase> Bullets;

        protected int CountOfBullets;



        protected AttackBase(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime, 
            int countOfBulletsForEasyMode) : base(danmaku, lifeTime)
        {
            OwnerObject = ownerObject;
            StartPoint = startPoint;
            CountOfBullets = (int) (countOfBulletsForEasyMode*danmaku.ComplexityFactor);
        }


        protected abstract Vector2f GetPosition(float fi);


        public virtual void OnCollision(object obj, EventArgs e)
        {
            Console.WriteLine(@"Столкновение произошло");
        }

        public override void Render()
        {
            foreach (var bullet in Bullets)
            {
                bullet?.Render();
            }
        }

    }
}
