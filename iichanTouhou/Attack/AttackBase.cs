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
            Died += OnDied;
        }


        public virtual void OnCollision(object obj, EventArgs e)
        {
            Console.WriteLine(@"Столкновение произошло");
        }


        public override void OnDied(object sender, EventArgs e)
        {
            if (Bullets.Count > 0)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Bullets[i].OnDied(null, null);
                }
                Bullets.Clear();
            }
            Console.WriteLine("Атака закончена");
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
