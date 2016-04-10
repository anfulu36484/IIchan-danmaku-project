using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Attack;
using SFML.System;

namespace iichanTouhou.Slice
{
    class SliceOfLife1:SliceOfLife
    {
        private Attack1 attack1;

        public SliceOfLife1(Danmaku danmaku) : base(danmaku)
        {
            attack1= new Attack1(danmaku,new Vector2f(500,200));
        }

        public override void LoadContent()
        {
            attack1.LoadContent();
        }

        public override void Initialize()
        {
            attack1.Initialize();
        }

        public override void Tick()
        {
           attack1.Tick();
        }

        public override void Render()
        {
            attack1.Render();
        }
    }
}
