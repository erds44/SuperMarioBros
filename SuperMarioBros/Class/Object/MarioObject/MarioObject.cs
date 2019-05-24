﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.MarioObject.MarioState;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject
{
    public class MarioObject : IObject
    {
        private IMarioState state;
        private ISprite sprite;
        private MarioGame game; //For future change game state.
        private Vector2 location;
        public MarioObject(MarioGame game, Vector2 location)
        {
            // Assume it is facing right, change later
            state = new RightIdleMarioState(this, "smallMario");
            this.game = game;
            this.location = location;
        }

        public void Left()
        {
            state.Left();
        }

        public void Down()
        {
            state.Down();
        }

        public void Up()
        {
            state.Up();
        }

        public void Right()
        {
            state.Right();
        }

        public void ToSmall()
        {
            state.ToSmall();
        }

        public void ToBig()
        {
            state.ToBig();
        }

        public void ToFire()
        {
            state.ToFire();
        }

        public void Die()
        {
            state.Die();
        }

        public void Move(Vector2 motion)
        {
            this.location += motion;
        }
        public void Update()
        {
            this.state.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 size = sprite.Size();
            sprite.Draw(spriteBatch, new Vector2(location.X, location.Y - size.Y));
            /* Could be sprite.Draw(spriteBatch, location); 
             * the sprite knows the size it needs to draw.
             * size is a vector2 attribute of Sprite class.
             * the sprite.Draw function could be 
             * public void Draw(SpriteBatch spriteBatch, Vector2 location)
             * {
             *  spriteBatch.Draw(texture, new Rectangle(location.x, location.y, size.x, size.y), white);
             * }
             * This is a scratch, I don't know if it works.
             */
        }
        public void UpdateSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void ChangeState(IMarioState marioState)
        {
            this.state = marioState;
        }
    }
}
