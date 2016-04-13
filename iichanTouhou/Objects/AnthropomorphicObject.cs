using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace iichanTouhou.Objects
{
    abstract class AnthropomorphicObject:GameObject
    {
        

        protected AnthropomorphicObject(Danmaku danmaku, Vector2f startPosition,
            Vector2f size, float hitboxRadius, double lifeTime, int XP) 
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
            
        }


    }
}
