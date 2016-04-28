using System;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1 :AttackBase
    {
        private AttackOfMainObject1Pool _attackOfMainObject1Pool;

        public AttackOfMainObject1(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, 
             int countOfBulletsForEasyMode, int timeBetweenAttacks) 
            : base(danmaku, ownerObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, countOfBulletsForEasyMode)
        {
            _timeBetweenAttacks = timeBetweenAttacks;
        }

        private int _timeBetweenAttacks;
        private int _nextTimeAttack;

        public override void Initialize()
        {
            _attackOfMainObject1Pool = new AttackOfMainObject1Pool((MainObject)OwnerObject);
            _timeBetweenAttacks = 60;
        }


        void Attack()
        {
            if (_nextTimeAttack == 0 || _nextTimeAttack >= LivedTime)
            {
                Bullets.Add(_attackOfMainObject1Pool.CreateObject());
                _nextTimeAttack = LivedTime - _nextTimeAttack;
            }
        }

        public override void Update()
        {
            base.Update();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                Attack();
            }

            for (int i = Bullets.Count - 1; i > -1; i--)
            {
                if (!Bullets[i].IsObjectInGameArea())
                {
                    _attackOfMainObject1Pool.Release((BulletForMainObject1)Bullets[i]);
                    Bullets.Remove(Bullets[i]);
                }
                else
                        Bullets[i].Update();
             }
        }

        protected override Vector2f GetPosition(float fi)
        {
            throw new NotImplementedException();
        }
    }
}
