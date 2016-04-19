using System;

namespace IIchanDanmakuProject
{
    abstract class GameElement :GameBase
    {

        protected readonly Danmaku Danmaku;

        protected GameElement(Danmaku danmaku, int lifeTimeInSeconds)
        {
            Danmaku = danmaku;
            _timeOfDeath = lifeTimeInSeconds * danmaku.FrameRateLimit;
        }


        private int _livedTime;

        private readonly int _timeOfDeath;

        public int LivedTimeInSeconds => _livedTime / Danmaku.FrameRateLimit;


        public int LivedTime
        {
            get { return _livedTime; }
            private set {
                _livedTime = value;
                if (_livedTime >= _timeOfDeath)
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

        public override void Update()
        {
            LivedTime++;
        }
    }
}
