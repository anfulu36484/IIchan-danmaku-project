using System;
using System.Collections.Generic;
using System.Linq;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using IIchanDanmakuProject.Objects.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    abstract class BulletBase :GameObject
    {
        public List<GameObject> TargetObjects { get; }
        public GameObject OwnerObject { get; }

        private List<float> _safeDistances;

        public event EventHandler<EventArgs> Collision;

        private RotatorBase _rotator;

        private void DefineSaveDistances(List<GameObject> targetObjects)
        {
            _safeDistances = new List<float>(targetObjects.Count);

            for (int i = 0; i < targetObjects.Count; i++)
            {
                _safeDistances.Add(this.HitboxRadius + TargetObjects[i].HitboxRadius);
            }
        }

        public void AddTargetObject(GameObject gameObject)
        {
            TargetObjects.Add(gameObject);
            _safeDistances.Add(this.HitboxRadius + gameObject.HitboxRadius);
        }

        protected BulletBase(Danmaku danmaku,
            Vector2f startPosition,
            Vector2f size,
            float hitboxRadius,
            GameObject targetObject,
            GameObject ownerObject,
            EventHandler<EventArgs> onCollision,
            int lifeTime,
            RotatorBase rotator)
            : this(danmaku, startPosition, size, hitboxRadius, new[] { targetObject }.ToList(), ownerObject, onCollision, lifeTime,
                 rotator)
        {

        }

        protected BulletBase(Danmaku danmaku,
            Vector2f startPosition,
            Vector2f size,
            float hitboxRadius,
            GameObject targetObject,
            GameObject ownerObject,
            EventHandler<EventArgs> onCollision,
            int lifeTime)
            :this (danmaku,startPosition,size,hitboxRadius, new[] { targetObject }.ToList(),ownerObject,onCollision,lifeTime,
                 new NoneRotator())
        {

        }


        protected BulletBase(Danmaku danmaku,
            Vector2f startPosition,
            Vector2f size,
            float hitboxRadius,
            List<GameObject> targetObjects,
            GameObject ownerObject,
            EventHandler<EventArgs> onCollision,
            int lifeTime, 
            RotatorBase rotator)
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
            TargetObjects = targetObjects;
            OwnerObject = ownerObject;
            DefineSaveDistances(TargetObjects);
            Collision += onCollision;
            _rotator = rotator;
            _rotator.AddBullet(this);
        }

        private bool IsCollisionDetection()
        {
            for (int i = 0; i < TargetObjects.Count; i++)
            {
                if((this.CenterCoordinates - TargetObjects[i].CenterCoordinates).Length() <= _safeDistances[i])
                    return true;
            }
            return false;
        }

        public override void Update()
        {
            base.Update();
            _rotator.Rotate();
            if (IsCollisionDetection())
            {
                Collision(this,new EventArgs());
            }
                
        }
    }
}
