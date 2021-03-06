﻿using System;
using IIchanDanmakuProject.Objects.Bullets.Behavior.Collision;
using SFML.System;

namespace IIchanDanmakuProject.Objects.Bullets.NPCBullets
{
    class Bullet3 :BulletBase
    {
        public Bullet3(Danmaku danmaku, Vector2f startPosition, Vector2f size, 
            float hitboxRadius, GameObject targetObject, GameObject ownerObject, EventHandler<EventArgs> onCollision, int lifeTime)
            : base(danmaku, startPosition, size, hitboxRadius, targetObject, ownerObject, onCollision, lifeTime, danmaku.Textures["bullet3"],
                  new StatChanger(-100))
        {
        }

    }
}
