using System;
using System.IO;
using IIchanDanmakuProject.Objects;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Statistics
{
    class PlayerSkin :GameObject
    {



        public PlayerSkin(Danmaku danmaku, Vector2f startPosition) 
            : base(danmaku, startPosition, new Vector2f(20,20), 0, danmaku.Textures["PlayerSkin"])
        {
        }

        private Shader shader;

        private RenderStates renderStates;

        public override void Initialize()
        {
            shader = new Shader(new MemoryStream(Properties.Resources.VertexShader),
                new MemoryStream(Properties.Resources.PlayerSkinFragmentShader));

            shader.SetParameter("texture", Shader.CurrentTexture);
            shader.SetParameter("factor", 0.5f);
            renderStates = new RenderStates(shader);
            renderStates.Texture = Texture;
        }

        private float _fillingFactor;

        public float FillingFactor
        {
            get { return _fillingFactor; }
            set
            {
                if (value<0 || value>1)
                    throw new ArgumentOutOfRangeException();
                _fillingFactor = value;
            }
        }

        public override void Update()
        {
            base.Update();
            shader.SetParameter("factor", FillingFactor);
        }

        public override void Render()
        {
            Danmaku.window.Draw(RectangleShape,renderStates);
        }
    }
}
