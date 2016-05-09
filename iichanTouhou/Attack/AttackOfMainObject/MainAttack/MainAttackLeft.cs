using IIchanDanmakuProject.Objects;
using SFML.System;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject.MainAttack
{
    class MainAttackLeft :AttackOfMainObjectBase
    {
        public MainAttackLeft(Danmaku danmaku, GameObject ownerObject, Vector2f startPoint, 
            int countOfBulletsForEasyMode, int timeBetweenAttacks) 
            : base(danmaku, ownerObject, startPoint, countOfBulletsForEasyMode, timeBetweenAttacks,
                  new MainAttackLeftPool(ownerObject))
        {
        }
    }
}
