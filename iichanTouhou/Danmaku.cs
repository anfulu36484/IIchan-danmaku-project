﻿using System.Windows.Forms;
using IIchanDanmakuProject;
using IIchanDanmakuProject.Area;
using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Slice;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace IIchanDanmakuProject
{
    class Danmaku:Game
    {

        public float ComplexityFactor = 1;

        public SliceOfLifeBase SliceOfLifeBase;

        public Textures Textures;

        public MainObject MainObject;

        private BackgroundArea backgroundArea;

        public GameArea GameArea;

        public StatisticsArea StatisticsArea;

        public Danmaku() 
            : base(1280, 960, "IIchan Danmaku Project", Color.Black)
        {
            window.Resized += Window_Resized;
            
            Textures = new Textures();

            backgroundArea = new BackgroundArea(this);
            GameArea = new GameArea(this);
            StatisticsArea = new StatisticsArea(this,GameArea);
            MainObject =new MainObject(this,new Vector2f(500,900),new Vector2f(20,20),5);
            SliceOfLifeBase = new SliceOfLife1(this,MainObject);

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
            Textures.Load();
            backgroundArea.Initialize();
            GameArea.Initialize();
            StatisticsArea.Initialize();
            MainObject.Initialize();
            SliceOfLifeBase.Initialize();
        }


        public override void Update()
        {
            backgroundArea.Initialize();
            GameArea.Update();
            StatisticsArea.Update();
            SliceOfLifeBase.Update();
        }

        public override void Render()
        {
            backgroundArea.Render();
            GameArea.Render();
            SliceOfLifeBase.Render();
            StatisticsArea.Render();
        }

        public void UpdateWindowSize()
        {
            Size = window.Size;
        }
    }
}
