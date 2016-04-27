using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIchanDanmakuProject.Objects.Bullets.Rotate;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets
{
    class Bulleto1:BulletBase
    {
        public Bulleto1(Danmaku danmaku, Vector2f startPosition,  GameObject targetObject, GameObject ownerObject, 
            EventHandler<EventArgs> onCollision) 
            : base(danmaku, startPosition, new Vector2f(40,40), 5, targetObject, ownerObject, onCollision,
                  int.MaxValue/danmaku.FrameRateLimit, new InDirectionOfMotionRotator())
        {
        }

        
        public override void Initialize()
        {
            Texture texture = new Texture(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Resources\bulleto1.png");
            this.Texture = texture;

            //Texture = danmaku.Textures["bullet11"];
        }
    }
}
