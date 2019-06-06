﻿using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Koopas.KoopaStates
{
    public class RightMovingGoombaState : IEnemyState
    {
        private readonly Koopa koopa;
        public RightMovingGoombaState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaMovingRight"));
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            koopa.ChangeState(new KoopaStompedState(koopa));
        }

        public void ChangeDirection()
        {
           koopa.ChangeState(new LeftMovingKoopaState(koopa));
            // More to do
        }
    }
}
