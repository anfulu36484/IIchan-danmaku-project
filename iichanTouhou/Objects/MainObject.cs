using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace iichanTouhou.Objects
{
    class MainObject :GameObject
    {
        private CircleShape obj;

        private float speed = 0.05f;

        public MainObject(Danmaku danmaku, int width, int height, Vector2f startPosition) 
            : base(danmaku, width, height, startPosition)
        {

        }

        public override void LoadContent()
        {

        }

        public override void Initialize()
        {
            obj = new CircleShape(10f);
            obj.Position = new Vector2f(500 - obj.Radius, 800 - obj.Radius);
            obj.FillColor = Color.Green;
            hitbox = new Hitbox(danmaku,10, 10, new Vector2f(CenterCoordinates.X-10, CenterCoordinates.Y-10),this );
        }

        public override void Tick()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                obj.Position -= new Vector2f(speed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                obj.Position += new Vector2f(speed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                obj.Position += new Vector2f(0, speed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                obj.Position -= new Vector2f(0, speed);
            }
        }

        public override void Render()
        {
            danmaku.window.Draw(obj);
        }


    }
}
