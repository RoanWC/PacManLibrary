﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public interface ICollidable
    {
        // delegates 
         int Points
        {
            get;
            set;
        }
        void Collide();
    }
}