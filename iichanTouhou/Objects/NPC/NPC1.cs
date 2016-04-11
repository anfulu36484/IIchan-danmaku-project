using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iichanTouhou.Attack;
using iichanTouhou.Helpers;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Objects.NPC
{
    class NPC1 :GameObject
    {
        public NPC1(Danmaku danmaku, int width, int height, Vector2f startPosition, float hitboxRadius) 
            : base(danmaku, width, height, startPosition,hitboxRadius)
        {
        }

        private Texture texture;
        private Sprite sprite;


        public override void LoadContent()
        {
            
        }

        public override void Initialize()
        {
            texture = TextureGenerator.Generate(Properties.Resources.npc, ImageFormat.Png);
            sprite = new Sprite(texture);
            sprite.Position = Position;
           
            Speed=new Vector2f(0,0.05f);
        }


        public override void Tick()
        {
            
            if (Position.Y > 300)
            {
                Speed = new Vector2f(0, 0);
                if (attack1 == null)
                    Attack();
            }
            Position += Speed;
            sprite.Position = Position;

            attack1?.Tick();
        }

        private Attack1 attack1;

        public void Attack()
        {
            attack1 = new Attack1(danmaku,this.CenterCoordinates);
            attack1.Initialize();
        }


        public override void Render()
        {
            danmaku.window.Draw(sprite);
            attack1?.Render();
        }
    }
}
