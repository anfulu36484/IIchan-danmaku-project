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

        public event EventHandler<SizeGameAreaEventArgs> Resized;


        public GameArea(Danmaku danmaku)
        {
            this.danmaku = danmaku;
            danmaku.window.Resized += Window_Resized;
        }



        private void Window_Resized(object sender, SizeEventArgs e)
        {
            rectangle.Scale = new Vector2f(danmaku.window.Size.X / (float)danmaku.Size.X,
                danmaku.window.Size.Y / (float)danmaku.Size.Y);
            if(Resized != null)
                Resized(this,new SizeGameAreaEventArgs(rectangle.Scale));
        }

        


        private RectangleShape rectangle;

        public override void LoadContent()
        {
            
        }


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

        

        public override void Tick()
        {
            

           /* float changeX = (float)danmaku.window.Size.X - (float)danmaku.Size.X;
            float changeY = (float)danmaku.window.Size.Y - (float)danmaku.Size.Y;

            if(changeX==0 & changeY==0)
                return;

            if (changeX <= changeY)
            {
                float newX = danmaku.window.Size.X*XShareOfWindow;
                float newY = newX/(XShareOfWindow/YShareOfWindow);
                rectangle.Scale = new Vector2f(newX/rectangle.Size.X, newY/ rectangle.Size.Y);
            }
            else
            {
                float newY = danmaku.window.Size.Y * YShareOfWindow;
                float newX = newY * (XShareOfWindow / YShareOfWindow);
                rectangle.Scale = new Vector2f(newX / rectangle.Size.X, newY /  rectangle.Size.Y);
            }
            */


        }

        public override void Render()
        {
            danmaku.window.Draw(rectangle);
        }
    }
}
