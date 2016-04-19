﻿using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects
{
    abstract class GameObject: GameElement
    {
        
        public Danmaku danmaku;

        protected RectangleShape rectangleShape;

        public virtual Vector2f Position
        {
            get { return rectangleShape.Position; } 
            set { rectangleShape.Position = value; }
        }

        public Vector2f Scale
        {
            get { return rectangleShape.Scale; }
            set { rectangleShape.Scale = value; }
        }

        public Vector2f Size
        {
            get { return rectangleShape.Size; }
            set { rectangleShape.Size = value; }
        }

        public Texture Texture
        {
            get { return rectangleShape.Texture; }
            set { rectangleShape.Texture = value; }
        }

        public float HitboxRadius;

        public Vector2f CenterCoordinates
        {
            get { return new Vector2f(Position.X + Size.X * 0.5f, Position.Y + Size.Y * 0.5f);}
            set { Position = new Vector2f(value.X- Size.X * 0.5f,value.Y- Size.Y * 0.5f); }
        }

        public Vector2f Speed = new Vector2f(0, 0);

      


        protected GameObject(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, int lifeTime) 
            : base(danmaku, lifeTime)
        {
            this.danmaku = danmaku;

            rectangleShape = new RectangleShape
            {
                Position = startPosition,
                Size = size
            };

            HitboxRadius = hitboxRadius;
        }




        public bool IsObjectInGameArea()
        {
            if (this.Position.X > danmaku.GameArea.Size.X
                || this.Position.Y > danmaku.GameArea.Size.Y
                || this.Position.X < danmaku.GameArea.Position.X- Size.X
                || this.Position.Y < danmaku.GameArea.Position.Y - Size.Y)
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
            danmaku.window.Draw(rectangleShape);
        }


    }
}
