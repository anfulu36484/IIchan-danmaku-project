using System;
using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.MainObjectBullets;
using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject.PowerSphere
{
    class PowerSphereAttack :AttackOfMainObjectBase
    {

        public PowerSphereAttack(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint,
            int countOfBulletsForEasyMode, int timeBetweenAttacks) 
            : base(danmaku, ownerObject, startPoint, countOfBulletsForEasyMode, timeBetweenAttacks,
                  new PowerSphereAttackPool(ownerObject))
        {
        }


        /*private readonly PowerSphereAttackPool _powerSphereAttackPool;

        public PowerSphereAttack(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, 
             int countOfBulletsForEasyMode, int timeBetweenAttacks) 
            : base(danmaku, ownerObject, startPoint, int.MaxValue/danmaku.FrameRateLimit, countOfBulletsForEasyMode)
        {
            _timeBetweenAttacks = timeBetweenAttacks;
            _powerSphereAttackPool = new PowerSphereAttackPool(ownerObject,OnCollision);
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
            _powerSphereAttackPool.Release((BulletForPowerSphere)obj);
            Bullets.Remove((BulletBase)obj);
        }


        void Attack()
        {
            if ( _nextTimeAttack <= LivedTime)
            {
                Bullets.Add(_powerSphereAttackPool.CreateObject());
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
                    _powerSphereAttackPool.Release((BulletForPowerSphere)Bullets[i]);
                    Bullets.Remove(Bullets[i]);
                }
                else
                        Bullets[i].Update();
             }
        }

        protected override Vector2f GetPosition(float fi)
        {
            throw new NotImplementedException();
        }*/


    }
}
