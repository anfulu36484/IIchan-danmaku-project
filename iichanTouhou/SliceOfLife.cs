using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects.ObjectsDeath;

namespace iichanTouhou
{
    abstract class SliceOfLife :GameBase
    {
        private readonly Danmaku _danmaku;

        public Shinigami Shinigami;

        protected SliceOfLife(Danmaku danmaku)
        {
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
        }

        public override void Render()
        {
            Shinigami.Render();
        }
    }
}
