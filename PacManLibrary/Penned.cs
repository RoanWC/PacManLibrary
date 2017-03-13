using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Penned : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        public event CollisionHandler Collision;

        /// <summary>
        /// Constructor for the penned state. 
        /// </summary>
        /// <param name="ghost">a hande to the ghost</param>
        /// <param name="maze">a handle to the maze</param>
        public Penned(Ghost ghost, Maze maze)
        {
            this.ghost = ghost;
            this.maze = maze;

        }
        /// <summary>
        /// deffines how the ghost will move inside the pen
        /// </summary>
        public void Move()
        {
            Tile current = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            int numPlaces = places.Count;

            if(numPlaces == 0)
            {
                throw new Exception("Nowhere to go");
            }
            Random rand = new Random();
            int choice = rand.Next(numPlaces);

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
        /// <summary>
        /// not supported for ghosts who are in the penned state
        /// </summary>
        public void Collide()
        {
            throw new NotSupportedException("Ghosts who are in the pen do not collide with anything");
        }
    }
}
