using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace iichanTouhou
{
    abstract class GameElement :GameBase
    {
        private double _lifeTime;

        protected readonly Danmaku Danmaku;

        protected GameElement(Danmaku danmaku, double lifeTime)
        {
            Danmaku = danmaku;
            _lifeTime = lifeTime;
        }
        
        public double Lifetime
        {
            get { return _lifeTime; }
            private set
            {
                _lifeTime = value;
                if (_lifeTime <= 0)
                {
                    Died?.Invoke(this, new EventArgs());
                }
            }
        }

        private int _XP = 1;

        protected int XP
        {
            get { return _XP; }
            set
            {
                _XP = value;
                if (_XP <= 0)
                {
                    Died?.Invoke(this, new EventArgs());
                }
            }
        }

        public event EventHandler Died;

        public override void Tick()
        {
            Lifetime--;
        }
    }
}
