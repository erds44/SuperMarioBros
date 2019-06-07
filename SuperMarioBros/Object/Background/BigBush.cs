﻿using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    class BigBush : AbstractBackground
    {

        public BigBush(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("BigBush");
        }
    }
}