using System;
using IIchanDanmakuProject.Helpers.ObjectPool;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1Pool :Pool<BulletForMainObject1>
    {
        private readonly GameObject _gameObject;
        private readonly EventHandler<EventArgs> _onCollision;

        public AttackOfMainObject1Pool(GameObject gameObject, EventHandler<EventArgs> onCollision)
        {
            _gameObject = gameObject;
            _onCollision = onCollision;
        }

        public override BulletForMainObject1 CreateObject()
        {
            var bullet = new BulletForMainObject1(_gameObject.danmaku, _gameObject.Position-new Vector2f(0,60),
                _gameObject.TargetObjects, _gameObject, _onCollision);
            bullet.Initialize();
            return bullet;
        }
    }
}
