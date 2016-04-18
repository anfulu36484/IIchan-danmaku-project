using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Area
{
    class BackgroundArea :AreaBase
    {
        public BackgroundArea(Danmaku danmaku)
            : base(danmaku, new Vector2f(0,0), new Vector2f(1,1))
        {
        }

        public override void Initialize()
        {
            Rectangle.FillColor = Color.Blue;
        }

        public override void Update() {}
    }
}
