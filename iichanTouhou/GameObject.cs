using SFML.System;

namespace iichanTouhou
{
    abstract class GameObject:GameBase
    {
        protected readonly Danmaku danmaku;
        protected readonly Hitbox _hitbox;

        public Vector2f Position;

        public int Width;
        public int Height;

        public Vector2f CenterCoordinates
        {
            get { return new Vector2f((float)(Position.X + Width * 0.5), (float)(Position.Y + Height * 0.5));}
            set { Position = new Vector2f((float)(value.X- Width * 0.5),(float)(value.Y- Height * 0.5)); }
        }

        protected Hitbox hitbox;

        protected GameObject(Danmaku danmaku, int width, int height, Vector2f startPosition)
        {
            this.danmaku = danmaku;
            Width = width;
            Height = height;
            _hitbox = hitbox;
            Position = startPosition;
            danmaku.gameArea.Resized += GameArea_Resized;

        }

        public Vector2f Speed;

        
        public virtual void GameArea_Resized(object sender, SizeGameAreaEventArgs e) { }

 
    }
}
