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
        public NPC1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius) 
            : base(danmaku, startPosition, size, hitboxRadius)
        {
        }

        public override void LoadContent()
        {
            
        }

        public override void Initialize()
        {
            Texture = TextureGenerator.Generate(Properties.Resources.npc, ImageFormat.Png);
           
            Speed=new Vector2f(0,0.7f);
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
            base.Render();
            attack1?.Render();
        }


    }
}
