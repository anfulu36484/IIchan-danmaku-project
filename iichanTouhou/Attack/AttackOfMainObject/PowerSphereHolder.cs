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

            //Console.WriteLine(Danmaku.MainObject.CenterCoordinates);
            //Console.WriteLine(nearestTargetObject.CenterCoordinates);
            //Console.WriteLine(Danmaku.MainObject.CenterCoordinates - nearestTargetObject.CenterCoordinates);
            return  nearestTargetObject.CenterCoordinates-Danmaku.MainObject.CenterCoordinates;
        }

        public override void Initialize()
        {
            Bullets = new List<BulletBase>(4);
            for (int i = 0; i < 4; i++)
            {
                Bullets.Add(new PowerSphere(Danmaku,Danmaku.MainObject.CenterCoordinates,
                    Danmaku.MainObject.TargetObjects, Danmaku.MainObject));
            }

            OffsetOfAngle = StartOffsetOfAngle + 30;
        }

        private float _r = 90;

        private float OffsetOf_r = 10;

        public float StartOffsetOfAngle = 120;

        public float OffsetOfAngle;


        void SetCoordinatesForBullet(BulletBase bullet, Vector2f centerCoordinatesOfMainObject, float r, float angle)
        {
            bullet.CenterCoordinates = centerCoordinatesOfMainObject + new PolarVector(r,angle).PolarToCartesianCoordinate();
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


            /*Trace.WriteLine("Угол"+angle);
            Bullets[0].Position = centerCoordOfMainObject + new Vector2f(-70, 20);
            Bullets[1].Position = centerCoordOfMainObject + new Vector2f(70, 20);

            Bullets[2].Position = centerCoordOfMainObject + new Vector2f(-90, -15);
            Bullets[3].Position = centerCoordOfMainObject + new Vector2f(90, -15);*/

            SetCoordinatesForBullet(Bullets[0], centerCoordOfMainObject, _r, angle + StartOffsetOfAngle);
            SetCoordinatesForBullet(Bullets[1], centerCoordOfMainObject, _r, angle - StartOffsetOfAngle);

            if (Danmaku.MainObject.PowerLevel != 3)
                SetCoordinatesForBullet(Bullets[2], centerCoordOfMainObject, _r + OffsetOf_r,
                    angle + OffsetOfAngle + StartOffsetOfAngle);
            else
                SetCoordinatesForBullet(Bullets[2], centerCoordOfMainObject, _r + OffsetOf_r,
                    angle +180);

            SetCoordinatesForBullet(Bullets[3], centerCoordOfMainObject, _r + OffsetOf_r, angle - OffsetOfAngle - StartOffsetOfAngle);
            
            for (int i = 0; i < Bullets.Count; i++)
            {
                Trace.WriteLine(i+"     "+Bullets[i].CenterCoordinates);
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
