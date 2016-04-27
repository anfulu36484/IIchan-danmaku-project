using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Objects;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1 :AttackBase
    {
        private AttackOfMainObject1Pool _attackOfMainObject1Pool;

        public AttackOfMainObject1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, 
             int countOfBulletsForEasyMode) 
            : base(danmaku, ownerObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, countOfBulletsForEasyMode)
        {
        }

        public override void Initialize()
        {
            _attackOfMainObject1Pool = new AttackOfMainObject1Pool((MainObject)OwnerObject);
        }

        public override void Update()
        {
            base.Update();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                _attackOfMainObject1Pool.CreateObject();
            }
        }

        protected override Vector2f GetPosition(float fi)
        {
            throw new NotImplementedException();
        }
    }
}
