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
            GameObjects.Add(npc1);
        }


    }
}
