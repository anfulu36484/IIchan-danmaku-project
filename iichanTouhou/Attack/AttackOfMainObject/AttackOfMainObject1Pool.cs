using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Helpers.ObjectPool;
using IIchanDanmakuProject.Objects.Bullets;

namespace IIchanDanmakuProject.Attack.AttackOfMainObject
{
    class AttackOfMainObject1Pool :Pool<Bulleto1>
    {
        public AttackOfMainObject1Pool()

        public override Bulleto1 CreateObject()
        {
            return new Bulleto1();
        }
    }
}
