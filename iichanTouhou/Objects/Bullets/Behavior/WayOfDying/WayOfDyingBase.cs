using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying
{
    abstract class WayOfDyingBase
    {
        protected readonly Danmaku Danmaku;
        protected BulletBase Bullet;

        protected WayOfDyingBase(Danmaku danmaku)
        {
            Danmaku = danmaku;
        }

        public void Initialize(BulletBase bullet)
        {
            Bullet = bullet;
        }

        public virtual void Run()
        {
        }
    }
}
