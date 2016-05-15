using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace IIchanDanmakuProject
{
    abstract class Game : GameBase
    {
        public RenderWindow window;
        protected Color clearColor;

        public Vector2u Size;

        public Clock Clock = new Clock();

        public int FrameRateLimit = 60;

        protected Game(uint width, uint height, string title, Color clearColor)
        {
            Size = new Vector2u(width,height);
            this.window = new RenderWindow(new VideoMode(width, height), title, Styles.Resize);
            this.clearColor = clearColor;
            window.SetActive(true);
            window.Position=new Vector2i(window.Position.X,0);
            window.SetFramerateLimit((uint)FrameRateLimit);
            // Set up events
            window.Closed += OnClosed;

        }

     
        public void Run()
        {
            Initialize();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                Update();

                window.Clear(clearColor);
                Render();
                window.Display();

                FPS = 1/Clock.ElapsedTime.AsSeconds();
                Clock.Restart();
            }
        }


        public float FPS;


        private void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }

    }
}


