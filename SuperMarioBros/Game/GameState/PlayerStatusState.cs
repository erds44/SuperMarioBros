﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.GameStates
{
    public class PlayerStatusState : IGameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly SpriteFont spriteFont;
        private readonly ISprite smallMarioSprite;
        private float timer = 3f;
        private readonly MarioGame game;
        public PlayerStatusState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = false;
            game.DisableController();
            graphicsDevice = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
            smallMarioSprite = SpriteFactory.CreateSprite(nameof(SmallMario) + nameof(RightIdle));
            game.IsMouseVisible = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.DrawString(spriteFont, "WORLD 1-1 " , new Vector2(350, 140), Color.White);
            smallMarioSprite.Draw(spriteBatch, new Vector2(332, 262));
            spriteBatch.DrawString(spriteFont, "  X   " + game.HeadsUps.Lives, new Vector2(382, 240), Color.White);
            spriteBatch.End();
        }

        public void Pause()
        {
           // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                game.State = new GameState(game);
            }                
        }
    }
}
