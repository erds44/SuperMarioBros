﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Stats;

namespace SuperMarioBros.GameStates
{
    public class PlayingState : GameState
    {
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;   
        public PlayingState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = false;
            if (game.IskeyboardController) game.InitializeKeyBoard();
            else game.InitializeGamePad();

            game.Player.DeathStateEvent += Die;
            StatsManager.Instance.timeUpEvent += TimeUp;

            if (MediaPlayer.State == MediaState.Paused) MediaPlayer.Resume();
            else if (game.Player.Position.Y > 0) { MediaPlayer.Play(AudioFactory.Instance.CreateSong("overworld")); }
            else { MediaPlayer.Play(AudioFactory.Instance.CreateSong("underworld")); backGroundColor = Color.Black; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            game.GraphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            MediaPlayer.Resume();
            game.Camera.Update();
            game.Controller.Update(gameTime);
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            StatsManager.Instance.Update(gameTime);
        }
        public override void Pause()
        {
            game.State = new PauseState(game);
        }
        public override void Die()
        {
            game.State = new PlayerDeadState(game);
        }
        public override void TimeUp()
        {
            game.Player.TimeOver();
            game.State = new PlayerDeadState(game);
        }

    }
}
