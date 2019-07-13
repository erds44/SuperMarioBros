﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Utility
{
    public class VectorEventArgs : EventArgs
    {
        public Vector2 vect;
        public VectorEventArgs(Vector2 vector)
        {
            this.vect = vector;
        }
    }
}
