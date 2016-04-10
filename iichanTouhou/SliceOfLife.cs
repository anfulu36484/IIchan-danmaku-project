using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iichanTouhou
{
    abstract class SliceOfLife :GameBase
    {
        private readonly Danmaku _game;


        protected SliceOfLife(Danmaku game)
        {
            _game = game;
        }

        protected void NextSlice(SliceOfLife sliceOfLife)
        {
            _game.sliceOfLife = sliceOfLife;
        }
    }
}
