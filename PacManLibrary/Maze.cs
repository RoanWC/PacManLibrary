using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Maze 
    {
        private Tile[,] maze;

        public Maze()
        {
            //base(x)
            //Still working on this one
            maze = new Maze
        }
        public void SetTiles(Tile[,] tile)
        {

        }

        

        public Tile this[int index1, int indexer2]
        {
            get
            {
                return maze[index1, indexer2];
            }

            set
            {
                maze[index1, indexer2] = value;
            }
        }

        //The length of a row
        public int Size
        {
            get { return maze.GetLength(0); }
        }

        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction direction)
        {
            List<Tile> availables = new List<Tile>();

            switch (direction)
            {
                case Direction.Left:
                    if(maze((int)position.X, (int)position.Y).Member//ghcfvhgvchj
                    break;

                case Direction.Right:
                    break;

                case Direction.Up:
                    break;

                case Direction.Down:
                    break;
            }
            return availables;
        }

        //There has to be a more efficient way to get this done but at the moment this is th eonly
        public void CheckMembersLeft()
        {
            for( int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++) {

                }
            }
        }
    }
}
