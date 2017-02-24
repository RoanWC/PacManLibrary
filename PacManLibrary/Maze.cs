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
            //Still working on this one
            maze = new Tile[(int)tilePosition.X, (int)tilePosition.Y];
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
    }
}
