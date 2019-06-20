﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Enemy;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        public bool IsInvalid { get; set; }

        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public EnemyPhysics physics;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update();
            Position += physics.Displacement(gameTime);
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public void MoveUp()
        {
            physics.MoveUp();
        }

        public void MoveDown()
        {
            physics.MoveDown();
        }

        public virtual void ReverseDirection()
        {
            
            //if(!(this.State.GetType() == typeof(LeftMoving)))
            //{
                //Console.WriteLine(this.State.GetType());
                //Console.WriteLine(typeof(LeftMoving));
            State.ChangeDirection();
            //}
            physics.ReverseVelocity();
        }

        public void Destroy()
        {
            //Game.Score += 100;
        }

        public abstract void TakeDamage();

        public abstract void Flip();

        public void MoveLeft()
        {
            State.ChangeDirection();
            physics.ReverseVelocity();
        }
        public void MoveRight()
        {
            State.ChangeDirection();
            physics.ReverseVelocity();
        }
    }
}
