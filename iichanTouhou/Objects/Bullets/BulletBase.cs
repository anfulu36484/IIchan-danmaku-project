using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;
using SFML.System;

namespace iichanTouhou.Objects.Bullets
{
    abstract class BulletBase :GameObject
    {
        protected GameObject TargetObject { get; }

        private readonly float safeDistance;

        public event EventHandler<EventArgs> Collision;

        protected BulletBase(Danmaku danmaku, 
            int width,
            int height,
            Vector2f startPosition, 
            float hitboxRadius, 
            GameObject targetObject,
            EventHandler<EventArgs> onCollision) 
            : base(danmaku, width, height, startPosition,hitboxRadius)
        {
            TargetObject = targetObject;
            safeDistance = this.HitboxRadius+targetObject.HitboxRadius;
            Collision += onCollision;
        }


        private bool IsCollisionDetection()
        {
            return (this.CenterCoordinates - TargetObject.CenterCoordinates).Length() < safeDistance;
        }

        public override void Tick()
        {
            if(IsCollisionDetection())
                Collision(this,new EventArgs());
        }

    }
}
