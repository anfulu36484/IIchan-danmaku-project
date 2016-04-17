using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Area
{
    class GameArea:AreaBase
    {

        public GameArea(Danmaku danmaku)
            : base(danmaku, new Vector2f(10, 10), new Vector2f(0.7f, 0.97f))
        {
        }

        public override void Initialize()
        {
            Rectangle.OutlineThickness = 2;
            Rectangle.OutlineColor = Color.Green;
            Rectangle.FillColor = Color.Black;
        }
  

        public override void Update(){}
  
    }
}
