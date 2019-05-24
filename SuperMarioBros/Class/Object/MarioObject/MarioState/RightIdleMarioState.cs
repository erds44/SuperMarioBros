﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightIdleMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;

        public RightIdleMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(type + "RightIdleSprite"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
        }

        public void Down()
        {
            mario.ChangeState(new RightCrouchingMarioState(mario, type));
        }

        public void Fire()
        {
            //Do nothing yet.
        }

        public void Right()
        {
            mario.ChangeState(new RightMovingMarioState(mario, type));
        }

        public void Left()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, type));
        }

        public void ToBig()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "bigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "fireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "smallMario"));
        }

        public void Up()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, type));
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
