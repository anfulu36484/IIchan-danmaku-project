using System.Windows.Markup;
using IIchanDanmakuProject.Objects;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Statistics
{
    class PlayerSkin :GameObject
    {
        private bool _active = true;

        public bool Active
        {
            get { return _active; }
            set
            {
                RectangleShape.FillColor = value ? new Color(255, 255, 255, 255) : new Color(255, 255, 255, 100);
                _active = value;
            }
        }


        public PlayerSkin(Danmaku danmaku, Vector2f startPosition) 
            : base(danmaku, startPosition, new Vector2f(20,20), 0, danmaku.Textures["PlayerSkin"])
        {
        }

        public override void Initialize()
        {

        }
    }
}
