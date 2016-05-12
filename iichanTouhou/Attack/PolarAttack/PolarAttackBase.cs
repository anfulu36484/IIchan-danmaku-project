using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.PolarAttack
{
    abstract class PolarAttackBase :AttackBase
    {
        protected readonly float AttackScale;

        protected float[] FiArray;

        protected double K;

        protected PolarAttackBase(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, int lifeTime,
            int countOfBulletsForEasyMode, float attackScale, double startValueOfconstantK)
            : base(danmaku, ownerObject, startPoint, lifeTime, countOfBulletsForEasyMode)
        {
            AttackScale = attackScale;
            K = startValueOfconstantK;
        }


        public override void Initialize()
        {
            FiArray = new float[CountOfBullets];
            for (int i = 0; i < CountOfBullets; i++)
            {
                FiArray[i] = i;
            }
            Bullets = new List<BulletBase>(CountOfBullets);
        }



        protected Vector2f ConvertToWindowCoordinates(double r, double fi)
        {
            return new PolarVector(r, fi).PolarToCartesianCoordinateRadian()*AttackScale + StartPoint;

                //new Vector2f((float)(r * Math.Cos(fi) * AttackScale + StartPoint.X), (float)(r * Math.Sin(fi)) * AttackScale + StartPoint.Y);
        }

    }
}
