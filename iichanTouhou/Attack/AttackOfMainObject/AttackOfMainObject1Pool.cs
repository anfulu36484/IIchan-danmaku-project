using IIchanDanmakuProject.Helpers.ObjectPool;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1Pool :Pool<BulletForMainObject1>
    {
        private readonly MainObject _mainObject;

        public AttackOfMainObject1Pool(MainObject mainObject)
        {
            _mainObject = mainObject;
        }

        public override BulletForMainObject1 CreateObject()
        {
            return new BulletForMainObject1(_mainObject.danmaku,_mainObject.CenterCoordinates+new Vector2f(0,20),
                _mainObject.TargetObjects,_mainObject,null);
        }
    }
}
