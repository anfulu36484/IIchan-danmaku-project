using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects
{
    abstract class GameObject: GameElement
    {
        
        public Danmaku danmaku;

        public RectangleShape RectangleShape;

        public virtual Vector2f Position
        {
            get { return RectangleShape.Position; } 
            set { RectangleShape.Position = value; }
        }

        public Vector2f Scale
        {
            get { return RectangleShape.Scale; }
            set { RectangleShape.Scale = value; }
        }

        public Vector2f Size
        {
            get { return RectangleShape.Size; }
            set { RectangleShape.Size = value; }
        }

        public Texture Texture
        {
            get { return RectangleShape.Texture; }
            set { RectangleShape.Texture = value; }
        }

        public float HitboxRadius;

        public Vector2f CenterCoordinates
        {
            get {return  new Vector2f(Position.X + Size.X * 0.5f, Position.Y + Size.Y * 0.5f);}
            set { Position = new Vector2f(value.X- Size.X * 0.5f,value.Y- Size.Y * 0.5f); }
        }

        public Vector2f Speed = new Vector2f(0, 0);



        public List<GameObject> TargetObjects;


        protected GameObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, Texture texture)
            :this(danmaku, startPosition, size, hitboxRadius, int.MaxValue/danmaku.FrameRateLimit, texture)
        {
            
        }

        protected GameObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, int lifeTime, Texture texture) 
            : base(danmaku, lifeTime)
        {
            this.danmaku = danmaku;

            RectangleShape = new RectangleShape
            {
                Position = startPosition,
                Size = size
            };

            Texture = texture;

            HitboxRadius = hitboxRadius;
        }

        

        public bool IsObjectInGameArea()
        {
            if (this.Position.X > danmaku.GameArea.Size.X
                || this.Position.Y > danmaku.GameArea.Size.Y
                || this.Position.X < danmaku.GameArea.Position.X- Size.X
                || this.Position.Y < danmaku.GameArea.Position.Y - Size.Y 
                || float.IsNaN(Position.X) 
                || float.IsNaN(Position.Y))
                return false;
            return true;
        }

        public override void Update()
        {
            base.Update();
            Position += Speed;
        }

        public override void Render()
        {
             danmaku.window.Draw(RectangleShape);
        }


    }
}
