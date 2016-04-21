using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects
{
    class MainObject :GameObject
    {
        private float ordinarySpeed = 5f;
        private float focusSpeed = 2f;

        private readonly Hitbox _hitbox;


        public int Score;

        public int Power;

        public MainObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius)
            : base(danmaku, startPosition, size, hitboxRadius, int.MaxValue/danmaku.FrameRateLimit)
        {
            _hitbox = new Hitbox(danmaku,this);
        }

        public override Vector2f Position
        {
            get { return RectangleShape.Position; }
            set
            {
                if(value.X>danmaku.GameArea.Position.X
                    & value.X<danmaku.GameArea.Size.X+ danmaku.GameArea.Position.X-this.Size.X
                    & value.Y>danmaku.GameArea.Position.Y
                    & value.Y<danmaku.GameArea.Size.Y+ danmaku.GameArea.Position.Y-this.Size.Y)
                    RectangleShape.Position = value;
            }
        }

        public override void Initialize()
        {
            RectangleShape.FillColor = Color.Green;
            _hitbox.Initialize();
        }

        void Move(float speed)
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


        public override void Update()
        {
            base.Update();

            Move(Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? focusSpeed : ordinarySpeed);

            _hitbox.Update();
        }

        public override void Render()
        {
            base.Render();
            _hitbox.Render();
        }
    }
}
