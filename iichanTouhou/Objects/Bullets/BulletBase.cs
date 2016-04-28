using System;
using System.Collections.Generic;
using System.Linq;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    abstract class BulletBase :GameObject
    {
        public GameObject OwnerObject { get; }

        private List<float> _safeDistances;

        public event EventHandler<EventArgs> Collision;

        private RotatorBase _rotator;

        protected DeterminantOfDirectionOfMovementBase DeterminantOfDirectionOfMovement;

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
            RotatorBase rotator,
            DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement)
            : this(danmaku, startPosition, size, hitboxRadius, new[] { targetObject }.ToList(), ownerObject, onCollision, lifeTime,
                 rotator, determinantOfDirectionOfMovement)
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
                 new NoneRotator(),
                 new NoneDeterminantOfDirectionOfMovement())
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
            RotatorBase rotator,
            DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement)
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
            TargetObjects = targetObjects;
            OwnerObject = ownerObject;
            DefineSaveDistances(TargetObjects);
            Collision += onCollision;
            _rotator = rotator;
            _rotator.Initialize(this);
            DeterminantOfDirectionOfMovement = determinantOfDirectionOfMovement;
            DeterminantOfDirectionOfMovement.Initialize(this);
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
            DeterminantOfDirectionOfMovement.Move();
            if (IsCollisionDetection())
            {
                Collision(this,new EventArgs());
            }
                
        }
    }
}
