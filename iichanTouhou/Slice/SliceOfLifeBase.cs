using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.ObjectsDeath;

namespace IIchanDanmakuProject.Slice
{
    abstract class SliceOfLifeBase :GameBase
    {
        public MainObject MainObject { get; }
        private readonly Danmaku _danmaku;

        public Shinigami Shinigami;

        protected SliceOfLifeBase(Danmaku danmaku, MainObject mainObject)
        {
            MainObject = mainObject;
            _danmaku = danmaku;
            Shinigami = new Shinigami(_danmaku);
        }

        protected void NextSlice(SliceOfLifeBase sliceOfLife)
        {
            _danmaku.SliceOfLifeBase = sliceOfLife;
        }

        public override void Update()
        {
            Shinigami.Update();
            MainObject.Update();
        }

        public override void Render()
        {
            Shinigami.Render();
            MainObject.Render();
        }
    }
}
