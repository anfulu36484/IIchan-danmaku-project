using IIchanDanmakuProject.Attack.AttackOfMainObject;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects
{
    class MainObject :GameObject
    {
        private float ordinarySpeed = 5f;
        private float focusSpeed = 2f;

        private readonly Hitbox _hitbox;


        private PowerSphereHolder _powerSphereHolder;

        public int Score;

        private int _power;

        public int Power
        {
            get { return _power; }
            set {
                _power = value < 0 ? 1 : value;
            }
        }


        public int PowerLevel
        {
            get
            {
                if (Power >= 0 & Power < 11)
                    return 0;
                if (Power > 10 & Power < 51)
                    return 1;
                if (Power > 50 & Power < 101)
                    return 2;
                if (Power > 100 & Power < 201)
                    return 3;
                return 4;
            }
        }

        public MainObject(Danmaku danmaku, Vector2f startPosition)
            : base(danmaku, startPosition, new Vector2f(50,70), 5, danmaku.Textures["greencirno"])
        {
            _hitbox = new Hitbox(danmaku,this);
            Texture.Smooth = true;
            Power = 300;
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
            _hitbox.Initialize();
            _powerSphereHolder = new PowerSphereHolder(Danmaku,CenterCoordinates);
            _powerSphereHolder.Initialize();
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
            _powerSphereHolder.Update();
        }

        public override void Render()
        {
            base.Render();
            _hitbox.Render();
            _powerSphereHolder.Render();
        }
    }
}
