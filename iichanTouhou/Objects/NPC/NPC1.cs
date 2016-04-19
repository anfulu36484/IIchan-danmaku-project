using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iichanTouhou.Attack;
using iichanTouhou.Attack.PolarAttack;
using iichanTouhou.Helpers;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Objects.NPC
{
    class NPC1 :GameObject
    {
        public NPC1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, int lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
        }


        public override void Initialize()
        {
            Texture = danmaku.Textures["npc"];

            Speed =new Vector2f(0,2f);
        }


        public override void Update()
        {
            base.Update();

            if (LivedTimeInSeconds == 1)
            {
                base.rectangleShape.Texture = danmaku.Textures["bullet2"];

                Speed = new Vector2f(0, 0);
                if (_flower2 == null)
                    Attack();
            }

 
            Position += Speed;

            _flower2?.Update();

            
        }

        private Flower2 _flower2;

        public void Attack()
        {
            _flower2 = new Flower2(danmaku,this, CenterCoordinates);
            _flower2.Initialize();
            _flower2.Died += FlowerDied;
        }

        private void FlowerDied(object sender, EventArgs e)
        {
            _flower2 = null;
        }

        public override void Render()
        {
            base.Render();
            _flower2?.Render();
        }


        
    }
}
