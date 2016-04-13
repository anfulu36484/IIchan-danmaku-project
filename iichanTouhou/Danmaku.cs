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


        public Danmaku() 
            : base(1280, 960, "IIchan Danmaku Project", Color.Black)
        {
            window.Resized += Window_Resized;
            
            gameArea = new GameArea(this);
            mainObject =new MainObject(this,new Vector2f(500,900),new Vector2f(20,20),10,double.PositiveInfinity);
            sliceOfLife = new SliceOfLife1(this);

            //нужно лучше стараться
            window.Size=new Vector2u(window.Size.X,(uint)(SystemInformation.PrimaryMonitorSize.Height*0.9f));
            Window_Resized(null, null);

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


        public override void Initialize()
        {
            gameArea.Initialize();
            mainObject.Initialize();
            sliceOfLife.Initialize();
        }


        public override void Tick()
        {
            gameArea.Tick();
            mainObject.Tick();
            sliceOfLife.Tick();
        }

        public override void Render()
        {
            gameArea.Render();
            mainObject.Render();
            sliceOfLife.Render(); 
        }

        public void UpdateWindowSize()
        {
            Size = window.Size;
        }
    }
}
