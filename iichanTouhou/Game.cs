using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iichanTouhou;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace iichanProject
{
    abstract class Game : GameBase
    {
        public RenderWindow window;
        protected Color clearColor;

        public Vector2u Size;

        protected Game(uint width, uint height, string title, Color clearColor)
        {
            Size = new Vector2u(width,height);
            this.window = new RenderWindow(new VideoMode(width, height), title, Styles.Resize);
            this.clearColor = clearColor;
            window.SetActive(true);
            window.Position=new Vector2i(window.Position.X,0);

            // Set up events
            window.Closed += OnClosed;
           
        }

     
        public void Run()
        {
            LoadContent();
            Initialize();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                Tick();

                window.Clear(clearColor);
                Render();
                window.Display();
            }
        }



        private void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }

        
    }
}


