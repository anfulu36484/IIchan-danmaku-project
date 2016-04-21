using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace IIchanDanmakuProject.Statistics
{
    class StatisticsView :GameBase
    {
        private readonly Danmaku _danmaku;
        private Font font;
        private Text scoreText;
        

        public StatisticsView(Danmaku danmaku)
        {
            _danmaku = danmaku;
        }

        public override void Initialize()
        {
            font = new Font(@"D:\С_2015\IIchan danmaku project\iichanTouhou\Statistics\arial.ttf");
            scoreText = new Text("Score 0",font);
            scoreText.Position = _danmaku.StatisticsArea.Position + new Vector2f(40, 40);
            scoreText.Scale = new Vector2f(1.2f,1.2f);
            scoreText.Color=Color.Cyan;
        }

        public override void Update()
        {
            scoreText.DisplayedString = "Score " + _danmaku.MainObject.Score;
        }

        public override void Render()
        {
            _danmaku.window.Draw(scoreText);
        }
    }
}
