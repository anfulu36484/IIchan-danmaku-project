using System.Collections.Generic;
using System.Globalization;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Statistics
{
    class StatisticsView :GameBase
    {
        private readonly Danmaku _danmaku;
        private Font _font;
        private Text _scoreText;
        private Text _powerText;
        private Text _playerText;

        private List<PlayerSkin> _playerSkins; 


        public StatisticsView(Danmaku danmaku)
        {
            _danmaku = danmaku;
        }

        public override void Initialize()
        {
            _font = new Font(Properties.Resources.arial);
            _scoreText = new Text("Score   0", _font)
            {
                Position = _danmaku.StatisticsArea.Position + new Vector2f(30, 40),
                Scale = new Vector2f(1.1f, 1.1f),
                Color = Color.White
            };

            _playerText = new Text("Player", _font)
            {
                Position = _danmaku.StatisticsArea.Position + new Vector2f(30, 100),
                Scale = new Vector2f(1.1f, 1.1f),
                Color = Color.White
            };

            _powerText = new Text("Power   0.00 / 4.00", _font)
            {
                Position = _danmaku.StatisticsArea.Position + new Vector2f(30, 160),
                Scale = new Vector2f(1.1f, 1.1f),
                Color = Color.White
            };

            _playerSkins= new List<PlayerSkin>();


            float bias = 120;
            for (int i = 0; i < _danmaku.MainObject.CountOfLivesMax ; i++, bias+=35)
            {
                PlayerSkin playerSkin  = new PlayerSkin(_danmaku, new Vector2f(_playerText.Position.X+bias, _playerText.Position.Y+15));
                playerSkin.Initialize();
                _playerSkins.Add(playerSkin);
            }
        }

        public override void Update()
        {
            _scoreText.DisplayedString = $"Score   {_danmaku.MainObject.Score}";
            _powerText.DisplayedString =  $"Power   {_danmaku.MainObject.Power.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US)"))} / 4.00";

            float lives = _danmaku.MainObject.CountOfLives;
            for (int i = 0; i < _danmaku.MainObject.CountOfLivesMax; i++)
            {
                if (lives >= 1)
                {
                    _playerSkins[i].FillingFactor = 1;
                    lives -= 1;
                }
                else if (lives < 1 & lives > 0)
                {
                    _playerSkins[i].FillingFactor = lives;
                    lives = 0;
                }
                else
                    _playerSkins[i].FillingFactor = 0;

                _playerSkins[i].Update();
            }

        }

        public override void Render()
        {
            _danmaku.window.Draw(_scoreText);
            _danmaku.window.Draw(_powerText);
            _danmaku.window.Draw(_playerText);

            for (int i = 0; i < _danmaku.MainObject.CountOfLivesMax; i++)
            {
                _playerSkins[i].Render();
            }
        }
    }
}
