﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Goombas
{
 
    public class FlippedGoomba : AbstractEnemy
    {
        public FlippedGoomba(Goomba goomba)
        {
            Sprite = goomba.Sprite;
            Position = goomba.Position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            //physics.velocity.X = 0;
            //physics.velocity.Y = -150;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            ((UniversalSprite)Sprite).Draw(spriteBatch, Position, SpriteEffects.FlipVertically);
        }

        public override void TakeDamage()
        {
            //Do Nothing
        }

        public override void Flip()
        {
            //DO Nothing
        }
    }
  
}
