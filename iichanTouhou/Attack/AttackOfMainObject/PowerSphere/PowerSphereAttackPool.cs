using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject.PowerSphere
{
    class PowerSphereAttackPool :BulletPoolBase
    {
        public PowerSphereAttackPool(GameObject gameObject) 
            : base(gameObject)
        {
        }

        public override BulletBase CreateObject()
        {
            var bullet = new BulletForPowerSphere(GameObject.danmaku, GameObject.CenterCoordinates,
                GameObject.TargetObjects, GameObject, OnCollision);
            bullet.CenterCoordinates = GameObject.CenterCoordinates;
            bullet.Initialize();
            return bullet;
        }

    }
}
