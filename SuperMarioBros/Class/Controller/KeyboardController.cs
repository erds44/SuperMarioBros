﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Command;

namespace SuperMarioBros.Class.Controller
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> inputKeys;
        public KeyboardController(params (Keys key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) element  in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }
        public void Add(Keys key, ICommand command)
        {
            inputKeys.Add(key, command);
        }
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                ICommand command;
                if (inputKeys.TryGetValue(key[0], out command))
                {
                    command.Execute();
                }
            }
        }
    }
}
