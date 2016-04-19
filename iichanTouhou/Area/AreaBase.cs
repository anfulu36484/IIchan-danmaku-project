using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Area
{
    abstract class AreaBase:GameBase
    {
        protected Danmaku Danmaku;

        public Vector2f Size
        {
            get { return Rectangle.Size; }
            set { Rectangle.Size = value; }
        }

        public Vector2f ShareOfWindow;

        public Vector2f Position
        {
            get { return Rectangle.Position; }
            set { Rectangle.Position = value; }
        }


        protected RectangleShape Rectangle;

        protected AreaBase(Danmaku danmaku, Vector2f startPosition,Vector2f shareOfWindow)
        {
            Danmaku = danmaku;
            Rectangle = new RectangleShape();
            Position = startPosition;
            ShareOfWindow = shareOfWindow;
            Size = new Vector2f(danmaku.window.Size.X * ShareOfWindow.X, danmaku.window.Size.Y * ShareOfWindow.Y);
        }

        public override void Render()
        {
            Danmaku.window.Draw(Rectangle);
        }
    }
}
