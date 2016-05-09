using IIchanDanmakuProject.Objects.Bullets.Bonuses;

namespace IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying
{
    class TurnIntoBonusWayOfDying :WayOfDyingBase
    {
        public TurnIntoBonusWayOfDying(Danmaku danmaku) : base(danmaku)
        {
        }

        public override void Run()
        {
            base.Run();
            if (Bullet.IsObjectInGameArea())
            {
                StarBonus starBonus = new StarBonus(Danmaku, Bullet.Position, Bullet.TargetObjects[0],
                    Danmaku.SliceOfLifeBase.Shinigami, Danmaku.SliceOfLifeBase.Shinigami.OnCollision);
                Danmaku.SliceOfLifeBase.Shinigami.Add(starBonus);
            }
        }
    }
}
