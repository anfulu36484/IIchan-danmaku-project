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

    }
}
