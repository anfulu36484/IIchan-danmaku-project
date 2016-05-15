using System.Collections.Generic;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;
using IIchanDanmakuProject.Objects.Bullets.Behavior.DirectionOfMovement;
using IIchanDanmakuProject.Objects.Bullets.NPCBullets;
using SFML.System;

namespace IIchanDanmakuProject.Attack.StandartAttack
{
    class DirectedAttack :AttackBase
    {
        public DirectedAttack(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint)
            : base(danmaku, ownerObject, startPoint, 500, 10)
        {
        }

        public override void Initialize()
        {
            Bullets = new List<BulletBase>(CountOfBullets);
            float fi = 10;
            for (int i = 0; i < CountOfBullets; i++)
            {
          /*      BulletBase bullet = new Bullet1(Danmaku, GetStartPosition(fi), new Vector2f(50, 50), 25, 
                    Danmaku.MainObject, OwnerObject,
                    OnCollision, int.MaxValue / Danmaku.FrameRateLimit);

                bullet.Initialize();
                Bullets.Add(bullet);

                fi += 10f;*/
            }
        }


        private int _timeBetweenAttacks;
        private int _nextTimeAttack;

        void Attack()
        {
           /* if (_nextTimeAttack <= LivedTime)
            {
                BulletBase bullet = new BulletForDirectedAttack(Danmaku,OwnerObject.CenterCoordinates,
                    Danmaku.MainObject,this,OnCollision,new MovementToNearestTargetObject())

                bullet.Initialize();

                Bullets.Add(_bulletPoolBase.CreateObject());
                _nextTimeAttack = LivedTime + _timeBetweenAttacks;
            }*/
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
