﻿using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class HiddenBlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        public HiddenBlockUsedCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            ObjectsManager.Instance.HiddenUsed(block);
        }
    }
}
