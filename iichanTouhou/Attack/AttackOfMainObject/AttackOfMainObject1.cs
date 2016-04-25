using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Objects;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1 :AttackBase
    {
        public AttackOfMainObject1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, 
             int countOfBulletsForEasyMode) 
            : base(danmaku, ownerObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, countOfBulletsForEasyMode)
        {
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override Vector2f GetPosition(float fi)
        {
            throw new NotImplementedException();
        }
    }
}
