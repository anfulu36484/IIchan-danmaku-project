using System;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.PolarAttack
{
    abstract class PolarAttackBase :AttackBase
    {
        private readonly float _attackScale;

        protected float[] FiArray;

        protected double K;

        protected PolarAttackBase(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime,
            int countOfBulletsForEasyMode, float attackScale, double startValueOfconstantK)
            : base(danmaku, ownerObject, startPoint, lifeTime, countOfBulletsForEasyMode)
        {
            _attackScale = attackScale;
            Died += PolarAttack_Died;
            K = startValueOfconstantK;
        }


        private void PolarAttack_Died(object sender, EventArgs e)
        {
            for (int i = 0; i < Bullets.Length; i++)
            {
                Danmaku.SliceOfLifeBase.Shinigami.AddAsBonus(Bullets[i]);
                Bullets[i] = null;
            }
        }

        public override void Initialize()
        {
            FiArray = new float[CountOfBullets];
            for (int i = 0; i < CountOfBullets; i++)
            {
                FiArray[i] = i;
            }
            Bullets = new BulletBase[CountOfBullets];
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


        protected Vector2f ConvertToCartesianCoordinates(double r, double fi)
        {
            return new Vector2f((float)(r * Math.Cos(fi) * _attackScale + StartPoint.X), (float)(r * Math.Sin(fi)) * _attackScale + StartPoint.Y);
        }


        
    }
}
