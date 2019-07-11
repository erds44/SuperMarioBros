﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class TeleportingState : GameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;
        public TeleportingState(MarioGame game)
        {
            game.DisableController();
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("pipe").Play();
            if (game.Player.Position.Y < 0) backGroundColor = Color.Black;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            game.ObjectsManager.Mario.Update(gameTime);
            game.CollisionManager.Update();
            game.Camera.Update();
        }
    }
}
