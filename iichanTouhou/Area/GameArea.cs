using System.IO;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Area
{
    class GameArea:AreaBase
    {
        private Shader _shader;

        private RenderStates _renderStates;

        private float _time;

        public GameArea(Danmaku danmaku)
            : base(danmaku, new Vector2f(10, 10), new Vector2f(0.7f, 0.97f))
        {
        }

        public override void Initialize()
        {
            Rectangle.OutlineThickness = 2;
            Rectangle.OutlineColor = Color.Green;

            Texture texture = new Texture((uint)Rectangle.Size.X, (uint)Rectangle.Size.Y);

            Rectangle.Texture = texture;

            _shader = new Shader(new MemoryStream(Properties.Resources.VertexShader),
                new MemoryStream(Properties.Resources.BackgroundFragmentShader));
            _shader.SetParameter("resolution", Rectangle.Size);
            _renderStates = new RenderStates(_shader);
            _renderStates.Texture = texture;

        }


        public override void Update()
        {
            _shader.SetParameter("time", _time);
            _time += 0.01f;
        }

        public override void Render()
        {
            Danmaku.window.Draw(Rectangle, _renderStates);
        }

    }
}
