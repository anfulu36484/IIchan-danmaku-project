using IIchanDanmakuProject.Attack.AttackOfMainObject.MainAttack;
using IIchanDanmakuProject.Attack.AttackOfMainObject.PowerSphere;
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

        private MainAttackRight _mainAttackRight;

        private MainAttackLeft _mainAttackLeft;

        public int Score;

        private float _power;

        public float Power
        {
            get { return _power; }
            set
            {
                if (value < 0)
                    _power = 0;
                else if (value > 4)
                    _power = 4;
                else
                    _power = value;
            }
        }


        public int PowerLevel => (int) Power;

        public int CountOfBomb => PowerLevel;


        public int CountOfLivesMax =5;


        private int _countOfLives = 3;

        public int CountOfLives
        {
            get { return _countOfLives; }
            set
            {
                if (value > CountOfLivesMax)
                    _countOfLives = CountOfLivesMax;
                else
                {
                    _countOfLives = value;
                }
            }
        }


        public MainObject(Danmaku danmaku, Vector2f startPosition)
            : base(danmaku, startPosition, new Vector2f(50,70), 5, danmaku.Textures["greencirno"])
        {
            _hitbox = new Hitbox(danmaku,this);
            Texture.Smooth = true;
            Power = 4;
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
            _mainAttackRight = new MainAttackRight(Danmaku,this,CenterCoordinates,50,1);
            _mainAttackRight.Initialize();
            _mainAttackLeft = new MainAttackLeft(Danmaku, this, CenterCoordinates, 50, 1);
            _mainAttackLeft.Initialize();
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
            _mainAttackRight.Update();
            _mainAttackLeft.Update();
        }

        public override void Render()
        {
            base.Render();
            _hitbox.Render();
            _powerSphereHolder.Render();
            _mainAttackRight.Render();
            _mainAttackLeft.Render();
        }
    }
}
