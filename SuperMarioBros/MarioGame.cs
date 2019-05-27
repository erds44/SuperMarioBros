﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Object.MarioObject;
using SuperMarioBros.Class.Controller;
using SuperMarioBros.Class.Object.GoombaObject;
using SuperMarioBros.Class.Command;
using SuperMarioBros.Class.Object.BlockObject;
using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Class.Object.MushroomObject;
using SuperMarioBros.Class.Object.ItemObject;

namespace SuperMarioBros
{
    public class MarioGame : Game
    {
        //private List<KeyboardController> controllers = new List<KeyboardController>();
        private KeyboardController controller;
        private SpriteBatch spriteBatch;
        private int delay;
        private MarioObject mario;
        private List<IObject> objects;
        private IBlockObject brickBlock;
        private IBlockObject hiddenBlock;
        private IBlockObject questionBlock;
        public MarioGame()
        {
            var graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            Content.RootDirectory = "Content";
            delay = 0;
        }
        protected override void Initialize()
        {
            SpriteFactory.Initialize(Content);
            InitializeObjectsAndKeys();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            //controllers.ForEach(element => element.Update());
            delay++;
            if (delay % 5 == 0)
            {
                controller.Update();
                mario.Update();
                objects.ForEach(element => element.Update());
                base.Update(gameTime);
                delay = 0;
            }
            
        }

        protected override void Draw(GameTime gameTime)
        {
            if (delay % 5 == 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                mario.Draw(spriteBatch);
                objects.ForEach(element => element.Draw(spriteBatch));
                base.Draw(gameTime);
            }
            

        }
        private void KeyBinding(KeyboardController controller)
        {
            IReceiver marioReceiver = new InputAction(mario);
            IReceiver gameReceiver = new InputAction(this);
            IReceiver brickBlockReceiver = new InputAction(brickBlock);
            IReceiver hiddenBlockReceiver = new InputAction(hiddenBlock);
            IReceiver questionBlockReceiver = new InputAction(questionBlock);
            controller.Add(Keys.Q, new Quit(gameReceiver));
            controller.Add(Keys.A, new LeftCommand(marioReceiver));
            controller.Add(Keys.S, new DownCommand(marioReceiver));
            controller.Add(Keys.D, new RightCommand(marioReceiver));
            controller.Add(Keys.W, new UpCommand(marioReceiver));
            controller.Add(Keys.Y, new SmallMarioCommand(marioReceiver));
            controller.Add(Keys.U, new BigMarioCommand(marioReceiver));
            controller.Add(Keys.I, new FireMarioCommand(marioReceiver));
            controller.Add(Keys.O, new DieCommand(marioReceiver));
            controller.Add(Keys.R, new ResetCommand(gameReceiver));
            controller.Add(Keys.Z, new QuestionToUsedCommand(questionBlockReceiver));
            controller.Add(Keys.X, new BrickToDisappearCommand(brickBlockReceiver));
            controller.Add(Keys.C, new HiddenToUsedCommand(hiddenBlockReceiver));
        }
        public void InitializeObjectsAndKeys()
        {
            objects = new List<IObject>();
            mario = new MarioObject(new Vector2(400, 300), "SmallMario");
            brickBlock = new BrickBlockObject(new Vector2(50, 150));
            hiddenBlock = new HiddenBlockObject(new Vector2(100, 150));
            questionBlock = new QuestionBlockObject(new Vector2(150, 150));

            objects.Add(mario);
            objects.Add(brickBlock);
            objects.Add(hiddenBlock);
            objects.Add(questionBlock);
            objects.Add(new GoombaObject(new Vector2(100, 100)));
            objects.Add(new MushroomObject(new Vector2(100, 50), 20, 120, "Green"));
            objects.Add(new MushroomObject(new Vector2(150, 50), 150, 250, "Red"));
            objects.Add(new CoinObject(new Vector2(50, 400)));
            objects.Add(new FlowerObject(new Vector2(100, 400)));
            objects.Add(new PipeObject(new Vector2(200, 400)));
            controller = new KeyboardController();
            KeyBinding(controller);
        }

    }
}
