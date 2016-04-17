using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects;
using iichanTouhou.Objects.ObjectsDeath;

namespace iichanTouhou
{
    abstract class SliceOfLife :GameBase
    {
        public MainObject MainObject { get; }
        private readonly Danmaku _danmaku;

        public Shinigami Shinigami;

        protected SliceOfLife(Danmaku danmaku, MainObject mainObject)
        {
            MainObject = mainObject;
            _danmaku = danmaku;
            Shinigami = new Shinigami(_danmaku);
        }

        protected void NextSlice(SliceOfLife sliceOfLife)
        {
            _danmaku.sliceOfLife = sliceOfLife;
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
