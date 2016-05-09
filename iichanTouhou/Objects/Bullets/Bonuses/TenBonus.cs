using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class TenBonus :BonusBase
    {

        public TenBonus(Danmaku danmaku, Vector2f startPosition)
            : base(danmaku, startPosition, danmaku.Textures["TenBonus"], new StatChanger(0, 0, 100))
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            RectangleShape.FillColor = new Color(255, 255, 255, 200);
 
        }

    }
}
