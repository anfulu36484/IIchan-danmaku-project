using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace iichanTouhou
{
    class Hitbox :GameObject
    {
        private readonly GameObject _gameObject;
        private readonly float _radius;

        public Hitbox(Danmaku danmaku, int width, int height, Vector2f startPosition,GameObject gameObject) :
            base(danmaku,width,height,startPosition)
        {
            _gameObject = gameObject;
            _radius = (float)width/2;
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Tick()
        {
            throw new NotImplementedException();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
