using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
    public class Chase : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        private Pacman pacman;
        private Vector2 target;

        /// <summary>
        /// three parameter constructor to instansiate the chase behavior for the ghost
        /// </summary>
        /// <param name="ghost">ghost that is going to be chasing</param>
        /// <param name="maze">maze that the ghost is in</param>
        /// <param name="target">point that the ghost is moving to</param>
        /// <param name="pacman">pacman </param>
        public Chase(Ghost ghost, Maze maze, Vector2 target, Pacman pacman)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.pacman = pacman;
            this.target = target;
        }

        /// <summary>
        /// Defines how the ghost will move when it is in chase mode
        /// </summary>
        public void move()
        {
            Tile current = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            int numPosible = places.Count;
            int i = 0;
            int choice = 0;
            float dist = places[i].GetDistance(target);

            for (int i = 0; i < numPosible; i++)
            {
                if (places[i].GetDistance(target) < dist)
                {
                    dist = places[i].GetDistance(target);
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
    }
}
