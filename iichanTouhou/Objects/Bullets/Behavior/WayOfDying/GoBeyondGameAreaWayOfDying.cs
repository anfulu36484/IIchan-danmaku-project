using IIchanDanmakuProject.Helpers;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying
{
    class GoBeyondGameAreaWayOfDying :WayOfDyingBase
    {
        public GoBeyondGameAreaWayOfDying(Danmaku danmaku) : base(danmaku)
        {
        }

        private float _speedFactor = 5;

        public override void Run()
        {
            base.Run();
            if (Bullet.IsObjectInGameArea())
            {
                Bullet.Speed = (Bullet.CenterCoordinates - Bullet.OwnerObject.CenterCoordinates).Normalize() * _speedFactor;
                Danmaku.SliceOfLifeBase.Shinigami.Add(Bullet);
            }
        }
    }
}
