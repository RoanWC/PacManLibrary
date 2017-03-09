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

        //The length of a row
        public int Size
        {
            get { return maze.GetLength(0); }
        }

        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction direction)
        {

            return List;
        }

        //There has to be a more efficient way to get this done but at the moment this is th eonly
        public void CheckMembersLeft()
        {
            for( int i = 0; i < maze.GetLength(0); i++)
            {
                for( int j = 0; j< maze.GetLength(1); j++)
                {

                }
            }
        }
    }
}
