using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Attack.PolarAttack;

namespace IIchanDanmakuProject.Helpers.ObjectPool
{
    abstract class Pool<T>
        where T:class
    {

        List<T> _pool = new List<T>();

        public T TakeSlot()
        {
            if (_pool.Count > 0)
            {
                T obj = _pool.Last();
                _pool.RemoveAt(_pool.Count - 1);
                return obj;
            }
            return CreateObject();
        }


        public void Release(T slot)
        {
            if(slot==null)
                throw new NullReferenceException();
            _pool.Add(slot);
        }

        public abstract T CreateObject();

    }
}
