﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The Tile class is the base for what will be walls and paths.
    /// This abstract Tile class will declare what we expect walls 
    /// and paths to be able to do at the basic level.
    /// </summary>
    public abstract class Tile
    {
        private Vector2 vector;


        public Tile(int x, int y)
        {
            vector.X = x;
            vector.Y = y;
        }

        public Vector2 Position
        {
            get
            {
                return vector;
            }
            set
            {
                vector = value;
            }
        }

        public abstract ICollidable Member();
        public abstract bool CanEnter();
        public abstract void Collide();
        public abstract bool IsEmpty();
        public float GetDistance(Vector2 goal)
        {
            return Vector2.Distance(vector, goal);
        }
    }
}
