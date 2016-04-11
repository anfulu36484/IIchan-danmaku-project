using SFML.System;

namespace iichanTouhou
{
    abstract class GameObject:GameBase
    {
        
        protected readonly Danmaku danmaku;

        public Vector2f Position;

        public int Width;
        public int Height;
        public float HitboxRadius;

        public Vector2f CenterCoordinates
        {
            get { return new Vector2f((float)(Position.X + Width * 0.5), (float)(Position.Y + Height * 0.5));}
            set { Position = new Vector2f((float)(value.X- Width * 0.5),(float)(value.Y- Height * 0.5)); }
        }

        protected GameObject(Danmaku danmaku, int width, int height, Vector2f startPosition, float hitboxRadius)
        {
            HitboxRadius = hitboxRadius;
            this.danmaku = danmaku;
            Width = width;
            Height = height;
            Position = startPosition;

        }

        public bool IsObjectInGameArea()
        {
            if (this.Position.X > danmaku.gameArea.Width 
                || this.Position.Y > danmaku.gameArea.Height
                || this.Position.X < danmaku.gameArea.Position.X- this.Width
                || this.Position.Y < danmaku.gameArea.Position.Y - this.Height)
                return false;
            return true;
        }

        public Vector2f Speed;


 
    }
}
