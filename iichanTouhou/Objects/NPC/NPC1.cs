using System;
using IIchanDanmakuProject.Attack.PolarAttack;
using IIchanDanmakuProject.Objects.Bullets.Bonuses;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;

namespace IIchanDanmakuProject.Objects.NPC
{
    class NPC1 :GameObject
    {
        public NPC1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, int lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime,danmaku.Textures["npc"])
        {
        }


        public override void Initialize()
        {
            Speed =new Vector2f(0,2f);
            XP = 200;
        }


        public override void Update()
        {
            base.Update();

            if (LivedTimeInSeconds == 2)
            {
                base.RectangleShape.Texture = danmaku.Textures["bullet2"];

                Speed = new Vector2f(0, 0);
                if (_flower2 == null)
                    Attack();
            }

            _flower2?.Update();

        }


        public override void OnDied(object sender, EventArgs e)
        {
            base.OnDied(sender, e);
            _flower2?.OnDied(this,new EventArgs());
            danmaku.SliceOfLifeBase.Shinigami.Add(new PowerBonus(Danmaku,CenterCoordinates));
            danmaku.SliceOfLifeBase.Shinigami.Add(new TenBonus(Danmaku, CenterCoordinates+new Vector2f(-40,0)));
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
