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


        protected BulletBase(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius,
            GameObject targetObject, EventHandler<EventArgs> onCollision, double lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
            TargetObject = targetObject;
            safeDistance = this.HitboxRadius + targetObject.HitboxRadius;
            Collision += onCollision;
        }


        private bool IsCollisionDetection()
        {
            float  x = (CenterCoordinates - TargetObject.CenterCoordinates).Length();
            return (CenterCoordinates - TargetObject.CenterCoordinates).Length() <= safeDistance;
        }

        public override void Tick()
        {
            base.Tick();
            if (IsCollisionDetection())
            {
                Console.WriteLine(this.CenterCoordinates+" "+ TargetObject.CenterCoordinates+" "+(this.CenterCoordinates - TargetObject.CenterCoordinates).Length() + " "+ safeDistance);
                Collision(this,new EventArgs());
            }
                
        }

        

    }
}
