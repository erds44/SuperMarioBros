﻿using System;
using SuperMarioBros.Object.Enemy;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class RightMovingGoombaState : IEnemyState
    {
        private readonly Goomba goomba;
        public RightMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            //Goomba moves left and right using the same sprite
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            goomba.ChangeState(new GoombaStompedState(goomba));
        }

        public void ChangeDirection()
        {
            goomba.ChangeState(new LeftMovingGoombaState(goomba));
            // More to do
        }
    }
}