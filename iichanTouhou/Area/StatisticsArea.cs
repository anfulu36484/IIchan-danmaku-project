using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Area
{
    class StatisticsArea :AreaBase
    {
        public StatisticsArea(Danmaku danmaku, GameArea gameArea) 
            : base(danmaku, new Vector2f( gameArea.Position.X+gameArea.Size.X+20,gameArea.Position.Y)
                  , new Vector2f(1-gameArea.ShareOfWindow.X-0.04f,gameArea.ShareOfWindow.Y))
        {
        }

        public override void Initialize()
        {
            Rectangle.OutlineThickness = 2;
            Rectangle.OutlineColor = Color.Yellow;
            Rectangle.FillColor = Color.Black;
        }

        public override void Update(){}
    }
}
