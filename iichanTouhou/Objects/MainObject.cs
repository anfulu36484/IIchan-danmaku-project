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
        private float speed = 5f;

        public MainObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius)
            : base(danmaku, startPosition, size, hitboxRadius, int.MaxValue/danmaku.FrameRateLimit)
        {
        }

        public override Vector2f Position
        {
            get { return rectangleShape.Position; }
            set
            {
                if(value.X>danmaku.GameArea.Position.X
                    & value.X<danmaku.GameArea.Size.X+ danmaku.GameArea.Position.X-this.Size.X
                    & value.Y>danmaku.GameArea.Position.Y
                    & value.Y<danmaku.GameArea.Size.Y+ danmaku.GameArea.Position.Y-this.Size.Y)
                    rectangleShape.Position = value;
            }
        }

        public override void Initialize()
        {
            rectangleShape.FillColor = Color.Green;
        }

        public override void Update()
        {
            base.Update();
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
