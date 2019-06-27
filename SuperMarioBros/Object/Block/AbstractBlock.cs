﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Managers;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public IBlockState State { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public Physics Physics { get; set; }
        public Type ItemType { get; protected set; }
        public bool HasItem { get; set; }
        public ObjectState ObjState { get; set; }
        public int bumpedCount;
        protected bool blockHasItem = false;
        public void Initialize()
        {
            ObjState = ObjectState.Normal;
            State = new NormalState(this);
            Physics = new Physics(Vector2.Zero, 0f, 0f);
        }
        public virtual void Destroy()
        {
            // Do Nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite?.Draw(spriteBatch, Position);
            //Sprite?.Draw(spriteBatch, Position,SpriteEffects.None, 0.8f);
        }

        public Rectangle HitBox()
        {
            Point size = SizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public virtual void Used()
        {
            State.Used();
        }
        public virtual void Bumped()
        {
            State.Bumped();
        }

        public virtual void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Sprite?.Update();
        }

        public virtual void Borken()
        {
            // Do Nothing
        }

    }
}
