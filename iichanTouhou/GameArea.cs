using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace iichanTouhou
{
    class GameArea:GameBase
    {
        private readonly Danmaku danmaku;


        public GameArea(Danmaku danmaku)
        {
            this.danmaku = danmaku;
        }

        public float Width => rectangle.Size.X;
        public float Height => rectangle.Size.Y;

        public Vector2f Position => rectangle.Position;

        private void Window_Resized(object sender, SizeEventArgs e)
        {
            rectangle.Scale = new Vector2f(danmaku.window.Size.X / (float)danmaku.Size.X,
                danmaku.window.Size.Y / (float)danmaku.Size.Y);
        }

        


        private RectangleShape rectangle;



        private float XShareOfWindow = 0.7f;

        private float YShareOfWindow = 0.97f;



        public override void Initialize()
        {
            rectangle = new RectangleShape();
            rectangle.Position = new Vector2f(10, 10);
            rectangle.Size = new Vector2f(danmaku.window.Size.X * XShareOfWindow, danmaku.window.Size.Y * YShareOfWindow);
            rectangle.OutlineThickness = 1;
            rectangle.OutlineColor = Color.Green;
        }

        

        public override void Update()
        {
            


        }

        public override void Render()
        {
            danmaku.window.Draw(rectangle);
        }
    }
}
