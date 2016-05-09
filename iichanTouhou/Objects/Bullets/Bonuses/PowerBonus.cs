using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Rotate;
using IIchanDanmakuProject.Objects.Bullets.Behavior.WayOfDying;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.Bonuses
{
    class PowerBonus :BulletBase
    {
        public PowerBonus(Danmaku danmaku, Vector2f startPosition) 
            : base(danmaku, startPosition, new Vector2f(35,35), 12, danmaku.MainObject,
                  danmaku.SliceOfLifeBase.Shinigami,
                  danmaku.SliceOfLifeBase.Shinigami.OnCollision, 
                  int.MaxValue/danmaku.FrameRateLimit, 
                  new NoneRotator(),
                  new MovementInPredeterminedDirection(new Vector2f(0,1)), 
                  danmaku.Textures["PowerBonus"],
                  new NoneWayOfDying(danmaku),
                  new StatChanger(0,10,0))
        {
            RectangleShape.FillColor = new Color(255, 255, 255, 200);
        }
    }
}
