using IIchanDanmakuProject.Helpers.ObjectPool;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1Pool :Pool<BulletForMainObject1>
    {
        private readonly MainObject _mainObject;
        private readonly AttackOfMainObject1 _attackOfMainObject1;

        public AttackOfMainObject1Pool(MainObject mainObject,AttackOfMainObject1 attackOfMainObject1)
        {
            _mainObject = mainObject;
            _attackOfMainObject1 = attackOfMainObject1;
        }

        public override BulletForMainObject1 CreateObject()
        {
            var bullet = new BulletForMainObject1(_mainObject.danmaku,_mainObject.CenterCoordinates-new Vector2f(0,60),
                _mainObject.TargetObjects,_mainObject,_attackOfMainObject1.OnCollision);
            bullet.Initialize();
            return bullet;
        }
    }
}
