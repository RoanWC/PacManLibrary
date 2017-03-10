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


        public Penned(Ghost ghost, Maze maze)
        {
            this.ghost = ghost;
            this.maze = maze;

        }
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
        public void Collision()
        {
            Collision?.invoke(ghost);
        }
    }
}
