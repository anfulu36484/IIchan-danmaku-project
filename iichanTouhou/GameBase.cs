using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iichanTouhou
{
    abstract class GameBase
    {
        public abstract void Initialize();

        public abstract void Tick();
        public abstract void Render();
    }


}
