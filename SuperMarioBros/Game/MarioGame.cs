﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Controllers;
using SuperMarioBros.Cameras;
using SuperMarioBros.Managers;
using SuperMarioBros.HeadsUps;
using SuperMarioBros.GameStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.SpriteFactories;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public sealed class MarioGame : Game
    {
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }
        private bool pause = false;

        public ObjectsManager ObjectsManager { get; set; }
        public Camera Camera { get => marioCamera; }
        public ControllerMessager controller;
        private SpriteBatch spriteBatch;
        public CollisionManager collisionManager;

        public Camera marioCamera;

        public HeadsUp HeadsUps { get; set; }
        public static MarioGame Instance { get; private set; }
        public IGameState State { get; set; }
        private GraphicsDeviceManager graphics;
        public MarioGame()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            WindowHeight = graphics.PreferredBackBufferHeight;
            WindowWidth = graphics.PreferredBackBufferWidth;
            Content.RootDirectory = "Content";
        }

        public void ChangeToFlagPoleState()
        {
            State = new FlagPoleState(graphics.GraphicsDevice, Content);
        }

        protected override void LoadContent()
        {
            //Song song = Content.Load<Song>("Musics/overworld");

            //MediaPlayer.Play(song);

            base.LoadContent();
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            State = new MenuState(graphics.GraphicsDevice, Content);
            SpriteFactory.Initialize(Content);
            marioCamera = new Camera();
            HeadsUps = new HeadsUp(Content);
            ObjectFactory.Instance.ItemCollectedEvent += HeadsUps.CoinCollected;
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            CheckPause();
            State.Update(gameTime);
            base.Update(gameTime);
        }

        private void CheckPause()
        {
            if (!pause && Keyboard.GetState().IsKeyDown(Keys.P))
            {
                pause = true;
                State.Pause();
            }
            else if (pause && Keyboard.GetState().IsKeyUp(Keys.P))
            {
                pause = false;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
        public void ChangeToPlayerStatusState()
        {
            State = new PlayerStatusState(graphics.GraphicsDevice, Content);
        }
        public void ChangeToGameOvertState()
        {
            State = new GameOverState(graphics.GraphicsDevice, Content);
        }
        public void ChangeToTeleportingState()
        {
            State = new TeleportingState(graphics.GraphicsDevice);
        }
       
        public void InitializeGame()
        {
            ObjectsManager = new ObjectsManager(new ObjectLoader(), HeadsUps);
            ObjectsManager.LevelLoading();
            ObjectsManager.Initialize();
            ObjectFactory.Instance.Initialize();
            //AudioFactory.Instance.Initialize(Content, "Content/sounds.xml", "Content/musics.xml");
            marioCamera.Reset(ObjectsManager.Mario);
            collisionManager = new CollisionManager();
            KeyBinding();

            //MediaPlayer.Play(AudioFactory.Instance.CreateSong("overworld"));

            ObjectsManager.Mario.DeathEvent += HeadsUps.OnMarioDeath;
            ObjectsManager.Mario.SlidingEvent += HeadsUps.AddFlagScore;
            ObjectsManager.Mario.DeathEvent += HeadsUps.ResetTimer;
            ObjectsManager.Mario.PowerUpEvent += HeadsUps.PowerUpCollected;
            ObjectsManager.Mario.ExtraLifeEvent += HeadsUps.ExtraLife;
            ObjectsManager.Mario.ClearingScoresEvent += HeadsUps.ClearingScores;
            HeadsUps.timerOverEvent += ObjectsManager.Mario.TimeOver;
        }

        public void ChangeToGameState()
        {
           State = new GameState(graphics.GraphicsDevice);
        }

        public void KeyBinding()
        {
            IMario mario = ObjectsManager.Mario;
            controller = new ControllerMessager(mario);
            IController keyboardController = new KeyboardController
                (controller,
                    (Keys.Q, ControllerMessager.QUITGAME),
                    (Keys.A, ControllerMessager.LEFTMOVE),
                    (Keys.S, ControllerMessager.DOWNMOVE),
                    (Keys.D, ControllerMessager.RIGHTMOVE),
                    (Keys.W, ControllerMessager.UPMOVE),
                    (Keys.Z, ControllerMessager.UPMOVE),
                    (Keys.R, ControllerMessager.RESETGAME),
                    (Keys.Left, ControllerMessager.LEFTMOVE),
                    (Keys.Down, ControllerMessager.DOWNMOVE),
                    (Keys.Right, ControllerMessager.RIGHTMOVE),
                    (Keys.Up, ControllerMessager.UPMOVE),
                    (Keys.X, ControllerMessager.POWER)
                );
            controller.AddController(keyboardController);
            IController JoyStickController = new JoyStickController(controller);
            controller.AddController(JoyStickController);
        }
        public void StartOver()
        {
            Initialize();
            InitializeGame();
            State = new MenuState(graphics.GraphicsDevice, Content);
        }

    }
}