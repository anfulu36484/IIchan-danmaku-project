using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;

namespace IIchanDanmakuProject.Objects
{
    class Shinigami:GameObject
    {
        List<BulletBase> _objects = new List<BulletBase>();

        public Shinigami(Danmaku danmaku) 
            : base(danmaku, new Vector2f(0,0), new Vector2f(0,0), 0, null)
        {
        }

 
        public void Add(BulletBase bullet)
        {
            _objects.Add(bullet);
        }


        public void OnCollision(object sender, EventArgs eventArgs)
        {
            _objects.Remove((BulletBase) sender);
        }


        public override void Initialize() {}


        private object _lockObj = new object();

        public override void Update()
        {
            lock (_lockObj)
            {
                for (int i = _objects.Count - 1; i > -1; i--)
                {
                    if (!_objects[i].IsObjectInGameArea())
                    {
                        _objects.Remove(_objects[i]);
                    }
                    else
                    {
                        _objects[i].Update();
                    }
                }
            }
        }

        

        public override void Render()
        {
            foreach (var obj in _objects)
            {
                obj.Render();
            }
        }

    }
}
