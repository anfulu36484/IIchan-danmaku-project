using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.Bullets;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject.MainAttack
{
    class MainAttackPool:BulletPoolBase
    {
        public MainAttackPool(GameObject gameObject) : base(gameObject)
        {
        }

        public override BulletBase CreateObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
