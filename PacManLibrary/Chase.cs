﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
    /// <summary>
    /// defines the behavior for ghosts who are in the chase state.
    /// </summary>
    public class Chase : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        private Pacman pacman;
        private Vector2 target;

       
        public event CollisionHandler Collision;

        /// <summary>
        /// three parameter constructor to instansiate the chase behavior for the ghost
        /// </summary>
        /// <param name="ghost">ghost that is going to be chasing</param>
        /// <param name="maze">maze that the ghost is in</param>
        /// <param name="target">point that the ghost is moving to</param>
        /// <param name="pacman">pacman </param>
        public Chase(Ghost ghost, Maze maze, Vector2 target, Pacman pacman,GhostPack gp)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.pacman = pacman;
            this.target = new Vector2(target.X, target.Y);
            Collision += gp.ResetGhost;
            Collision += pacman.ResetPacManPosition;
        }

        /// <summary>
        /// Defines how the ghost will move when it is in chase mode
        /// </summary>
        public void Move()
        {
            Tile current = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            int numPosible = places.Count;
            int i = 0;
            int choice = 0;
            float dist = places[i].GetDistance(pacman.PacManPosition + target);

            for (i = 0; i < numPosible; i++)
            {
                if (places[i].GetDistance(pacman.PacManPosition + target) < dist)
                {
                    dist = places[i].GetDistance(pacman.PacManPosition + target);
                    choice = i;
                }
            }

            if (places[choice].Position.X == ghost.Position.X + 1)
                ghost.Direction = Direction.Right;
            else if (places[choice].Position.X == ghost.Position.X - 1)
                ghost.Direction = Direction.Left;
            else if (places[choice].Position.Y == ghost.Position.Y - 1)
                ghost.Direction = Direction.Up;
            else
                ghost.Direction = Direction.Down;

            ghost.Position = places[choice].Position;
         }

        public void Collide()
        {
            Collision?.Invoke(ghost);   
        }
    }
}
