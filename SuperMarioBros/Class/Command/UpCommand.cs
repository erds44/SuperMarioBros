﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class UpCommand : ICommand
    {
        private IReceiver action;
        public UpCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Up();
        }
    }
}
