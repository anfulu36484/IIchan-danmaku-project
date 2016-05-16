using System;
using System.Diagnostics;
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

        Stopwatch _stopwatch = new Stopwatch();


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

            _stopwatch.Start();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                Update();

                window.Clear(clearColor);
                Render();
                window.Display();

                FPS = 1/(float)_stopwatch.ElapsedMilliseconds*1000;
                _stopwatch.Restart();
            }
        }


        public float FPS;


        private void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }

    }
}


