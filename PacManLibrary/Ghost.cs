﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;

namespace PacManLibrary
{
    public class Ghost : IMovable
    {
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Direction direction;
        private Color color;
        private IGhostState currentState;
        private Timer scared;
        public Vector2 Position
        {
            get
            {
                return Position;
            }
            set
            {
                this.Position = value;
            }
        }

        public void move()
        {
            throw new NotImplementedException();
        }
    }
}