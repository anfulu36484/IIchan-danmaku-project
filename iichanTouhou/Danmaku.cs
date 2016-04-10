using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iichanProject;
using iichanTouhou.Attack;
using iichanTouhou.Objects;
using iichanTouhou.Slice;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace iichanTouhou
{
    class Danmaku:Game
    {

        public SliceOfLife sliceOfLife;

        public MainObject mainObject;

        public GameArea gameArea;

        private Attack1 attack1;

        public Danmaku() 
            : base(1280, 960, "IIchan Danmaku Project", Color.Black)
        {
            window.Resized += Window_Resized;
            
            gameArea = new GameArea(this);
            mainObject = new MainObject(this, 20,20,new Vector2f(500,600));
            sliceOfLife = new SliceOfLife1(this);

            //нужно лучше стараться
            /*window.Size=new Vector2u(window.Size.X,(uint)(SystemInformation.PrimaryMonitorSize.Height*0.9f));
            Window_Resized(null, null);*/


            attack1=new Attack1(this,new Vector2f(500,200));
        }

        private float scaleFactor = 1.33f; // width/height

        private void Window_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            float newScaleFactor = (float)window.Size.X / (float)window.Size.Y;

            if (newScaleFactor > scaleFactor)
            {
                window.Size = new Vector2u(window.Size.X, (uint)(window.Size.X / scaleFactor));
                UpdateWindowSize();
            }
            if (newScaleFactor < scaleFactor)
            {
                window.Size = new Vector2u((uint)(scaleFactor * window.Size.Y), window.Size.Y);
                UpdateWindowSize();
            }
        }

        public override void LoadContent()
        {
            gameArea.LoadContent();
            mainObject.LoadContent();
            //sliceOfLife.LoadContent();
            attack1.LoadContent();
        }

        public override void Initialize()
        {
            gameArea.Initialize();
            mainObject.Initialize();
            //sliceOfLife.Initialize();
            attack1.Initialize();
        }


        public override void Tick()
        {
            gameArea.Tick();
            mainObject.Tick();
            //sliceOfLife.Tick();
            attack1.Tick();
        }

        public override void Render()
        {
            gameArea.Render();
            mainObject.Render();
            //sliceOfLife.Render(); 
            attack1.Render();
        }

        public void UpdateWindowSize()
        {
            Size = window.Size;
        }
    }
}
