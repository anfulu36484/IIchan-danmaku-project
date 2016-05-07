using System;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    abstract class BulletPoolBase :Pool<BulletBase>
    {
        protected readonly GameObject GameObject;
        public EventHandler<EventArgs> OnCollision;

        protected BulletPoolBase(GameObject gameObject)
        {
            GameObject = gameObject;
        }

    }
}
