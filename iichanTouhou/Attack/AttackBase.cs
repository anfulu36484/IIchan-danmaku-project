using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects.Bullets;
using SFML.System;

namespace iichanTouhou.Attack
{
    abstract class AttackBase :GameBase
    {
        private readonly Danmaku _danmaku;
        private readonly Vector2f _startPoint;

        private BulletBase[] bullets;

        private readonly int countOfBullets = 100;
        
        protected AttackBase(Danmaku danmaku, Vector2f startPoint)
        {
            _danmaku = danmaku;
            _startPoint = startPoint;
        }

        protected abstract Vector2f GetStartOfPoint(float fi, float r);
      

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
