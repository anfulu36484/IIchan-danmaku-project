using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Objects.Bullets;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Attack
{
    class Attack1 : GameBase
    {
        private readonly Danmaku _danmaku;
        private readonly Vector2f _startPoint;

        private Bullet1[] bullet1s;

        private int countOfBullets = 100;


        Vector2f GetStartOfPoint(float fi, float r)
        {
            return new Vector2f((float)(r*Math.Sin(fi)+_startPoint.X),(float)(r*Math.Cos(fi) + _startPoint.Y));
        }

        
        public Attack1(Danmaku danmaku, Vector2f startPoint)
        {
            _danmaku = danmaku;
            _startPoint = startPoint;
        }


        public override void Initialize()
        {
            bullet1s = new Bullet1[countOfBullets];
            float fi = 10;
            for (int i = 0; i < countOfBullets; i++)
            {
                bullet1s[i]=new Bullet1(_danmaku,10,10, GetStartOfPoint(fi,fi));
                bullet1s[i].Initialize();
                bullet1s[i].Speed = (bullet1s[i].Position - _startPoint)*0.0005f;
                fi += 10f;
            }
        }

        public override void LoadContent()
        {
        }


        public override void Render()
        {
            foreach (var bullet1 in bullet1s)
            {
                bullet1?.Render();
            }
        }



        public override void Tick()
        {
            for (int i = 0; i < bullet1s.Length; i++)
            {
                if (bullet1s[i] != null)
                {
                    bullet1s[i].Tick();
                    if (!bullet1s[i].IsObjectInGameArea())
                        bullet1s[i] = null;
                }
            }
        }

    }
}
