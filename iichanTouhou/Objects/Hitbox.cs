using SFML.System;
using SFML.Window;

namespace IIchanDanmakuProject.Objects
{
    class Hitbox :GameObject
    {

        private readonly GameObject _ownerObject;

        public Hitbox(Danmaku danmaku, GameObject ownerObject)  
            : base(danmaku, 
                  ownerObject.CenterCoordinates- new Vector2f(ownerObject.HitboxRadius, ownerObject.HitboxRadius), 
                  new Vector2f(ownerObject.HitboxRadius*2, ownerObject.HitboxRadius * 2), 
                  ownerObject.HitboxRadius, danmaku.Textures["hitbox"]
                  )
        {
            _ownerObject = ownerObject;
        }

        public override void Initialize()
        {
        }

        public override void Update()
        {
            base.Update();
            Position = _ownerObject.CenterCoordinates - this.Size*0.5f;
        }

        public override void Render()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
            {
                base.Render();
            }
        }
    }
}
