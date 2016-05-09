using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class PowerBonus :BonusBase
    {

        public PowerBonus(Danmaku danmaku, Vector2f startPosition)
            : base(danmaku, startPosition, danmaku.Textures["PowerBonus"], new StatChanger(0, 10, 0))
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            RectangleShape.FillColor = new Color(255, 255, 255, 200);
        }

    }
}
