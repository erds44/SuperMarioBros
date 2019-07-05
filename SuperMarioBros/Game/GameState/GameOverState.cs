﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class GameOverState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private float timer = 2f;
        private ContentManager content;
        public GameOverState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            spriteFont = content.Load<SpriteFont>("Font/MarioFont");
            this.content = content;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, "GameOver", new Vector2(350, 240), Color.White);
            spriteBatch.End();
        }

        public void Pause()
        {
            //Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                MarioGame.Instance.HeadsUps.ResetAll();
                MarioGame.Instance.State = new MenuState(graphicsDevice, content);
            }
        }
    }
}
