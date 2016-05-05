using System;
using System.Collections.Generic;
using System.Diagnostics;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class PowerSphereHolder :AttackBase
    {


        public PowerSphereHolder(Danmaku danmaku, Vector2f startPoint) 
            : base(danmaku, danmaku.MainObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, 0)
        {

        }

        GameObject GetNearestTargetObject()
        {
            if (Danmaku.MainObject.TargetObjects.Count > 0)
            {
                float minDistance = (Danmaku.MainObject.TargetObjects[0].CenterCoordinates - Danmaku.MainObject.CenterCoordinates).Length();
                GameObject nearestTargetObject = Danmaku.MainObject.TargetObjects[0];

                for (int i = 0; i < Danmaku.MainObject.TargetObjects.Count; i++)
                {
                    float distance = (Danmaku.MainObject.TargetObjects[i].CenterCoordinates - Danmaku.MainObject.CenterCoordinates).Length();
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestTargetObject = Danmaku.MainObject.TargetObjects[i];
                    }
                }
                return nearestTargetObject;
            }
            return null;
        }

        Vector2f GetDistanceBeforeNearestTargetObject(GameObject nearestTargetObject)
        {
            return  nearestTargetObject.CenterCoordinates-Danmaku.MainObject.CenterCoordinates;
        }

        public override void Initialize()
        {
            Bullets = new List<BulletBase>(4);
            for (int i = 0; i < 4; i++)
            {
                BulletBase bullet = new PowerSphere(Danmaku, Danmaku.MainObject.CenterCoordinates,
                    Danmaku.MainObject.TargetObjects, Danmaku.MainObject);
                bullet.Initialize();
                Bullets.Add(bullet);
            }

            OffsetOfAngle = StartOffsetOfAngle + 30;
        }

        private float _r = 90;

        private float OffsetOf_r = 10;

        public float StartOffsetOfAngle = 120;

        public float OffsetOfAngle;


        void SetCoordinatesForBullet(BulletBase bullet, Vector2f centerCoordinatesOfMainObject, float r, float angle)
        {
            bullet.Position = centerCoordinatesOfMainObject + new PolarVector(r,angle).PolarToCartesianCoordinate();
        }


        public override void Update()
        {
            base.Update();

            float angle;

            GameObject nearestTargetObject = GetNearestTargetObject();

            if (nearestTargetObject != null)
            {
                angle = /*360-*/GetDistanceBeforeNearestTargetObject(nearestTargetObject).CartesianToPolarCoordinate().theta;
                
            }
            else
                angle = /*360-*/270;

            Vector2f centerCoordOfMainObject = Danmaku.MainObject.CenterCoordinates;


            SetCoordinatesForBullet(Bullets[0], centerCoordOfMainObject, _r, angle + StartOffsetOfAngle);
            SetCoordinatesForBullet(Bullets[1], centerCoordOfMainObject, _r, angle - StartOffsetOfAngle);

            if (Danmaku.MainObject.PowerLevel != 3)
                SetCoordinatesForBullet(Bullets[2], centerCoordOfMainObject, _r + OffsetOf_r,
                    angle + OffsetOfAngle + StartOffsetOfAngle);
            else
                SetCoordinatesForBullet(Bullets[2], centerCoordOfMainObject, _r + OffsetOf_r,
                    angle +180);

            SetCoordinatesForBullet(Bullets[3], centerCoordOfMainObject, _r + OffsetOf_r, angle - OffsetOfAngle - StartOffsetOfAngle);

            foreach (var bullet in Bullets)
            {
                bullet.Update();
            }

        }

        public override void Render()
        {
            for (int i = 1; i < Danmaku.MainObject.PowerLevel+1; i++)
            {
                Bullets[i-1].Render();
            }
        }

        protected override Vector2f GetPosition(float fi)
        {
            throw new NotImplementedException();
        }
    }
}
