﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SuperMarioBros.HeadsUps
{
    public class HeadsUp
    {
        public event Action timerOverEvent;
        private readonly ContentManager content;
        private readonly SpriteFont spriteFont;
        private readonly float scoreOffset = 83;
        private readonly float coinOffset = 246;
        private readonly float worldOffset = 400;
        private readonly float timeOffset = 532;
        private readonly float livesOffset = 666;

        private float timer = 10;
        private int score = 0;
        private int coin = 0;
        public int Lives { get; set; }
        public HeadsUp(ContentManager contentManager)
        {
            content = contentManager;
            spriteFont = content.Load<SpriteFont>("Font");
            Lives = 3;
        }
        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                timerOverEvent?.Invoke();
                timer = 0;
            }
        }
        public void Draw (SpriteBatch spriteBatch, float leftBound)
        {
            DrawHelper(spriteBatch, "SCORE", new Vector2(scoreOffset + leftBound, 5));
            DrawHelper(spriteBatch, score.ToString(), new Vector2(scoreOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "COINS", new Vector2(coinOffset + leftBound, 5));
            DrawHelper(spriteBatch, coin.ToString(), new Vector2(coinOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "WORLD", new Vector2(worldOffset + leftBound, 5));
            DrawHelper(spriteBatch, "1-1", new Vector2(worldOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "TIME", new Vector2(timeOffset + leftBound, 5));
            DrawHelper(spriteBatch, ((int)timer).ToString(), new Vector2(timeOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "LIVES", new Vector2(livesOffset + leftBound, 5));
            DrawHelper(spriteBatch, Lives.ToString(), new Vector2(livesOffset + leftBound + 10, 30));
        }
        public void OnMarioDeath()
        {
            Lives--;
            if (Lives == 0)
                MarioGame.Instance.ChangeToGameOvertState();
            else
                MarioGame.Instance.ChangeToPlayerStatusState();
        }
        public void CoinCollected(Vector2 Position)
        {
            coin++;
            score += 200;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "200");
        }
        public void EnemyStomped(Vector2 position, int count)
        {
            int addScore = 100 * count;
            score += addScore;
            ObjectFactory.Instance.CreateScoreText(position, spriteFont, addScore.ToString());
        }
        public void ResetTimer()
        {
            timer = 400;
        }
        public void ResetAll()
        {
            timer = 400;
            coin = 0;
            score = 0;
            Lives = 3;
        }
        public void ExtraLife(Vector2 Position)
        {
            Lives++;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1LF");
        }
        public void PowerUpCollected(Vector2 Position)
        {
            score += 1000;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1000");
        }
        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
