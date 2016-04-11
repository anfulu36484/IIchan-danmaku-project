using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace iichanTouhou.Objects.Bullets
{
    abstract class BulletBase :GameObject
    {
        protected GameObject TargetObject { get; set; }

        protected BulletBase(Danmaku danmaku, int width, int height, Vector2f startPosition, GameObject targetObject) 
            : base(danmaku, width, height, startPosition)
        {
            TargetObject = targetObject;
        }


 
    }
}
