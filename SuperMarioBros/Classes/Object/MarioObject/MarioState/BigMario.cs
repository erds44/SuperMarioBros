﻿using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;
using System;

namespace SuperMarioBros.Classes.Object.MarioObject
{
    public class BigMario : IMarioState
    {
        private readonly IMario mario;
        public BigMario(IMario mario)
        {
            this.mario = mario;
        }
        public void FireFlower()
        {
            mario.ChangeMarioState(new FireMario(mario));
        }

        public void GreenMushroom()
        {
            // Do Nothing
        }

        public void RedMushroom()
        {
            // Do Nothing
        }

        public void TakeDamage()
        {
            mario.ChangeMarioState(new SmallMario(mario));
        }
    }
}
