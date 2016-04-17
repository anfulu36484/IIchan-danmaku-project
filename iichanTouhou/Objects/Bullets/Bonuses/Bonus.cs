using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou.Helpers;
using iichanTouhou.Objects.ObjectsDeath;
using SFML.System;

namespace iichanTouhou.Objects.Bullets.Bonuses
{
    class Bonus :BulletBase
    {
        public Bonus(Danmaku danmaku, Vector2f startPosition,GameObject targetObject,
            GameObject ownerObject, EventHandler<EventArgs> onCollision)
        : base(danmaku, startPosition, new Vector2f(5,5),2, targetObject, ownerObject, onCollision, double.PositiveInfinity)
        {
            Texture = TextureGenerator.Generate(Properties.Resources.Bonus, ImageFormat.Png);
        }


        public override void Initialize()
        {

        }

        private float _speedFactor = 5;

        public override void Update()
        {
            Speed = (TargetObjects[0].CenterCoordinates - CenterCoordinates).Normalize()*_speedFactor;
            base.Update();
        }

        
    }
}
