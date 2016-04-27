using System;
using IIchanDanmakuProject.Attack.PolarAttack;
using IIchanDanmakuProject.Attack.StandartAttack;
using SFML.System;

namespace IIchanDanmakuProject.Objects.NPC
{
    class NPC_Standart :GameObject
    {
        public NPC_Standart(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, int lifeTime)
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

            if (LivedTimeInSeconds == 2)
            {
                base.RectangleShape.Texture = danmaku.Textures["bullet2"];

                Speed = new Vector2f(0, 0);
                if (_attack1 == null)
                    Attack();
            }

            _attack1?.Update();

            
        }

        private Attack1 _attack1;

        public void Attack()
        {
            _attack1 = new Attack1(danmaku, this, CenterCoordinates, int.MaxValue/danmaku.FrameRateLimit, 50);
            _attack1.Initialize();
            _attack1.Died += FlowerDied;
        }

        private void FlowerDied(object sender, EventArgs e)
        {
            _attack1 = null;
        }

        public override void Render()
        {
            base.Render();
            _attack1?.Render();
        }


        
    }
}
