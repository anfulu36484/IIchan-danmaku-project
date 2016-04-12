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
        private float speed = 1.5f;


        public MainObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius) 
            : base(danmaku, startPosition, size, hitboxRadius)
        {
        }

        public override void LoadContent()
        {

        }

        public override void Initialize()
        {
            rectangleShape.FillColor = Color.Green;
        }

        public override void Tick()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                Position -= new Vector2f(speed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                Position += new Vector2f(speed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                Position += new Vector2f(0, speed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                Position -= new Vector2f(0, speed);
            }
        }


    }
}
