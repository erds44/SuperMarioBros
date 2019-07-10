﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    class UniversalSprite : ISprite
    {
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int width;
        private readonly int height;
        private readonly int totalFrame;
        private float dt = 0f;
        private float delayTime;
        private Collection<Color> SpriteColor;
        private int colorIndex;
        private float layerDepth;
        private int delay;
        public UniversalSprite(Texture2D texture, int frame,int spriteDelay)
        {
            delay = 0;
            delayTime = spriteDelay/60f;
            colorIndex = 0;
            currentFrame = 0;
            layerDepth = 0.5f;
            this.texture = texture;
            totalFrame = frame;
            width = texture.Width / totalFrame;
            height = texture.Height;
            SpriteColor = new Collection<Color> { Color.White };
        }
        /* Set color and Set layer can be passed into the Draw Method 
            but that serves only for very few cases
            so we just make some methods instead
         */
        public void SetColor(Collection<Color> colors)
        {
            SpriteColor = colors;
        }
        public void SetLayer(float layer)
        {
            layerDepth = layer;
        }
        public void Update(GameTime gameTime)
        {
            dt += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (dt>delayTime)  
            if(delay %5 ==0)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 0;
                dt = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location,SpriteEffects spriteEffects = SpriteEffects.None, float scale = 1f)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Vector2 Position = new Vector2((int)location.X, (int)location.Y - height * scale);
            /* This condition is used for alternating colors for star mario
            *  aim to slow color changing rate 
            */
             delay++;
            if (SpriteColor.Count > 1)
            {
               
                if (delay % 5 == 0)
                {
                    colorIndex++;
                }
                    
                if (colorIndex % SpriteColor.Count == 0 || colorIndex > SpriteColor.Count)
                    colorIndex = 1;
            }
            
            Color spriteColor = SpriteColor[colorIndex];
            spriteBatch.Draw(texture, Position, sourceRectangle, spriteColor, 0f, Vector2.Zero, scale, spriteEffects, layerDepth);
        }
    }
}
