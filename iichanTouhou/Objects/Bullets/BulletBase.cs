using System;
using System.Collections.Generic;
using System.Linq;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    abstract class BulletBase :GameObject
    {
        public GameObject OwnerObject { get; }
        protected WayOfDyingBase WayOfDyingBase { get; }

        private List<float> _safeDistances;

        public event EventHandler<EventArgs> Collision;

        private RotatorBase _rotator;

        protected DeterminantOfDirectionOfMovementBase DeterminantOfDirectionOfMovement;

        protected StatChanger StatChanger;

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
            DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement,
            Texture texture,
            WayOfDyingBase wayOfDyingBase,
            StatChanger statChanger
            )
            : this(danmaku, startPosition, size, hitboxRadius, new[] { targetObject }.ToList(), ownerObject, onCollision, lifeTime,
                 rotator, determinantOfDirectionOfMovement,texture, wayOfDyingBase,statChanger)
        {

        }

        protected BulletBase(Danmaku danmaku,
            Vector2f startPosition,
            Vector2f size,
            float hitboxRadius,
            GameObject targetObject,
            GameObject ownerObject,
            EventHandler<EventArgs> onCollision,
            int lifeTime,
            Texture texture,
            StatChanger statChanger)
            :this (danmaku,startPosition,size,hitboxRadius, new[] { targetObject }.ToList(),ownerObject,onCollision,lifeTime,
                 new NoneRotator(),
                 new NoneDeterminantOfDirectionOfMovement(),
                 texture,
                 new NoneWayOfDying(danmaku),
                 statChanger)
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
            DeterminantOfDirectionOfMovementBase determinantOfDirectionOfMovement,
            Texture texture,
            WayOfDyingBase wayOfDyingBase,
            StatChanger statChanger
            )
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime,texture)
        {
            TargetObjects = targetObjects;
            OwnerObject = ownerObject;
            WayOfDyingBase = wayOfDyingBase;
            DefineSaveDistances(TargetObjects);
            Collision += onCollision;
            _rotator = rotator;
            _rotator.Initialize(this);
            DeterminantOfDirectionOfMovement = determinantOfDirectionOfMovement;
            DeterminantOfDirectionOfMovement.Initialize(this);
            WayOfDyingBase.Initialize(this);
            StatChanger = statChanger;
        }

        private GameObject GetCollidedObject()
        {
            for (int i = 0; i < TargetObjects.Count; i++)
            {
                if((this.CenterCoordinates - TargetObjects[i].CenterCoordinates).Length() <= _safeDistances[i])
                    return TargetObjects[i];
            }
            return null;
        }

        public override void OnDied(object sender, EventArgs e)
        {
            base.OnDied(sender, e);
            WayOfDyingBase.Run();
        }

        public override void Initialize(){}

        public override void Update()
        {
            base.Update();
            _rotator.Rotate();
            DeterminantOfDirectionOfMovement.Move();

            GameObject collidedObject = GetCollidedObject();

            if (collidedObject!=null)
            {
                StatChanger.ChangeStats(collidedObject);
                Collision(this,new CollisionEventArgs(collidedObject));
            }
                
        }
    }

    class CollisionEventArgs : EventArgs
    {
        public GameObject CollidedObject { get; }

        public CollisionEventArgs(GameObject collidedObject)
        {
            CollidedObject = collidedObject;
        }
    }
}
