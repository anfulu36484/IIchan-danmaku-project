using IIchanDanmakuProject.Objects;
using IIchanDanmakuProject.Objects.NPC;
using SFML.System;

namespace IIchanDanmakuProject.Slice
{
    class SliceOfLife1:SliceOfLifeBase
    {
        private NPC1 npc1;

        public SliceOfLife1(Danmaku danmaku, MainObject mainObject) : base(danmaku, mainObject)
        {
            npc1 = new NPC1(danmaku,new Vector2f(500,-100),new Vector2f(50,50),25 ,int.MaxValue/60 );
        }

        public override void Initialize()
        {
            npc1.Initialize();
        }

        public override void Update()
        {
            base.Update();
            npc1.Update();
        }

        public override void Render()
        {
            base.Render();
            npc1.Render();
        }
    }
}
