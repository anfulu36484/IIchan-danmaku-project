using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Helpers;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.Bonuses;
using SFML.System;

namespace IIchanDanmakuProject.Objects.ObjectsDeath
{
    class Shinigami:GameObject
    {
        List<BulletBase> _objects = new List<BulletBase>();

        public Shinigami(Danmaku danmaku) 
            : base(danmaku, new Vector2f(0,0), new Vector2f(0,0), 0, int.MaxValue/60)
        {
        }

        private float speedFactor = 5;

        public void Add(BulletBase bullet)
        {
            if (bullet.IsObjectInGameArea())
            {
                bullet.Speed = (bullet.CenterCoordinates - bullet.OwnerObject.CenterCoordinates).Normalize()*speedFactor;
                _objects.Add(bullet);
            }
        }

        public void AddAsBonus(BulletBase bullet)
        {
            if (bullet.IsObjectInGameArea())
            {
                Bonus bonus = new Bonus(danmaku, bullet.Position, bullet.TargetObjects[0], this, OnCollision);
                _objects.Add(bonus);
            }
        }


        List<BulletBase> _objectsForRemoval=new List<BulletBase>();

        private void OnCollision(object sender, EventArgs eventArgs)
        {
            _objectsForRemoval.Add((BulletBase)sender);
        }


        public override void Initialize() {}


        private void CompletelyRemoveObjects()
        {
            BulletBase[] objectsForRemovalTemp = _objectsForRemoval.ToArray();

            for (int i = 0; i < objectsForRemovalTemp.Length; i++)
            {
                _objects.Remove(objectsForRemovalTemp[i]);
                _objectsForRemoval.Remove(objectsForRemovalTemp[i]);
            }
        }

        public override void Update()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (!_objects[i].IsObjectInGameArea())
                {
                    _objectsForRemoval.Add(_objects[i]);
                }
                else
                {
                    _objects[i].Update();
                }

            }

            CompletelyRemoveObjects();
        }

        

        public override void Render()
        {
            foreach (var obj in _objects)
            {
                obj?.Render();
            }
        }

    }
}
