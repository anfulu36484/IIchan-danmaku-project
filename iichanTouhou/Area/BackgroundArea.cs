using System.IO;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Area
{
    class BackgroundArea :AreaBase
    {
        public BackgroundArea(Danmaku danmaku)
            : base(danmaku, new Vector2f(0,0), new Vector2f(1,1))
        {
        }

       

        public override void Initialize()
        {
            Rectangle.FillColor=new Color(50,50,100);
        }

        public override void Update()
        {
            
        }

        
    }
}
