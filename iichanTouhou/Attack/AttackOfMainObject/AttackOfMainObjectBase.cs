using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    abstract class AttackOfMainObjectBase :AttackBase
    {
        private readonly BulletPoolBase _bulletPoolBase;

        protected AttackOfMainObjectBase(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint,
             int countOfBulletsForEasyMode, int timeBetweenAttacks, BulletPoolBase poolBase) 
            : base(danmaku, ownerObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, countOfBulletsForEasyMode)
        {
            _timeBetweenAttacks = timeBetweenAttacks;
            _bulletPoolBase = poolBase;
            _bulletPoolBase.OnCollision += OnCollision;
        }

        private int _timeBetweenAttacks;
        private int _nextTimeAttack;

        public override void Initialize()
        {
            _timeBetweenAttacks = 7;
            Bullets = new List<BulletBase>();
        }

        public override void OnCollision(object obj, EventArgs e)
        {
            _bulletPoolBase.Release((BulletBase)obj);
            Bullets.Remove((BulletBase)obj);
        }


        void Attack()
        {
            if (_nextTimeAttack <= LivedTime)
            {
                Bullets.Add(_bulletPoolBase.CreateObject());
                _nextTimeAttack = LivedTime + _timeBetweenAttacks;
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
                    _bulletPoolBase.Release(Bullets[i]);
                    Bullets.Remove(Bullets[i]);
                }
                else
                    Bullets[i].Update();
            }
        }

    }
}
