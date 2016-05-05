using System.Collections.Generic;
using IIchanDanmakuProject.Objects;

namespace IIchanDanmakuProject.Slice
{
    abstract class SliceOfLifeBase :GameBase
    {
        public MainObject MainObject { get; }
        private readonly Danmaku _danmaku;

        public Shinigami Shinigami;

        public List<GameObject> GameObjects;

        protected SliceOfLifeBase(Danmaku danmaku, MainObject mainObject)
        {
            MainObject = mainObject;
            _danmaku = danmaku;
            Shinigami = new Shinigami(_danmaku);
            GameObjects = new List<GameObject>();
            MainObject.TargetObjects = GameObjects;
        }

        public void AddNPC(GameObject gameObject)
        {
            gameObject.Died += GameObject_Died;
            GameObjects.Add(gameObject);
        }

        private void GameObject_Died(object sender, System.EventArgs e)
        {
            GameObjects.Remove((GameObject) sender);
        }

        protected void NextSlice(SliceOfLifeBase sliceOfLife)
        {
            _danmaku.SliceOfLifeBase = sliceOfLife;
        }

        public override void Initialize()
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject?.Initialize();
            }
        }

        public override void Update()
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject?.Update();
            }
            MainObject.Update();
            Shinigami.Update();
        }

        public override void Render()
        {
            MainObject.Render();
            foreach (var gameObject in GameObjects)
            {
                gameObject?.Render();
            }
            
            Shinigami.Render();
        }
    }
}
