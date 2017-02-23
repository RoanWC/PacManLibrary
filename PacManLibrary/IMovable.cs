﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public interface IMovable
    {

        Direction direction
        {
            get;
            set;
        }

        Vector2 Position
        {
            get;
            set;
        }




        void move();


    }
}
