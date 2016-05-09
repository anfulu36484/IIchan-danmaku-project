using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject.MainAttack
{
    class MainAttackRightPool:BulletPoolBase
    {
        public MainAttackRightPool(GameObject gameObject) : base(gameObject)
        {
        }

        public override BulletBase CreateObject()
        {
            var bullet= new BulletForMainAttack(GameObject.danmaku, GameObject.CenterCoordinates,
                GameObject.TargetObjects, GameObject, OnCollision);
            bullet.CenterCoordinates = GameObject.CenterCoordinates + new Vector2f(25, -60);
            bullet.Initialize();
            return bullet;
        }
    }
}
