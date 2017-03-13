using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The Maze class is going to contain the list of all the
    /// tiles. The maze is made up of a 2d array of tiles and 
    /// the event PacmanWon will be thrown when all tiles are 
    /// empty.
    /// </summary>
    public class Maze 
    {
        private Tile[,] maze;
        private int size;
        public event PacmanWonHandler PacmanWon;

        /// <summary>
        /// This is an empty constructor becasue setTiles is 
        /// responsible for setting all of the tiles.
        /// </summary>
        //public Maze() 
        //{}
        /// <summary>
        /// This method takes in a 2d array of tiles and sets 
        /// the maze variable to the tiles.
        /// </summary>
        /// <param name="tile"></param>
        public void SetTiles(Tile[,] tile)
        {
            this.maze = tile;
            Size = tile.GetLength(0);
            
        }

        /// <summary>
        /// This indexer will take as input two integers,
        /// and these integers will refer to a position in
        /// the 2d array.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        public Tile this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index2 < 0 ||
                   index1 >= Size || index2 >= Size)
                    throw new ArgumentOutOfRangeException("The indexes must be in range");
                return maze[index1, index2];
            }

            set
            {
                if (index1 < 0 || index2 < 0 ||
                   index1 > Size || index2 > Size)
                    throw new ArgumentOutOfRangeException("The indexes must be in range");
                maze[index1, index2] = value;
            }
        }

        //This property will return the size of the maze.
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// This method will take a position and a direction as input and using the
        /// position it will check all sides except for the opposite direction for 
        /// an available tile that can be entered. 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns>List<Tile></returns>
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction direction)
        {
            List<Tile> availables = new List<Tile>();
            int x = (int)position.X;
            int y = (int)position.Y;
            switch (direction)
            {
                case Direction.Left:
                    if(maze[x - 1, y].CanEnter())
                        availables.Add(maze[x - 1, y]);//Left
                    if(maze[x, y-1].CanEnter())
                        availables.Add(maze[x, y - 1]);//Up
                    if(maze[x, y+1].CanEnter())
                        availables.Add(maze[x, y + 1]);//Down
                    break;

                case Direction.Right:
                    if (maze[x, y-1].CanEnter())
                        availables.Add(maze[x, y - 1]);//Up
                    if (maze[x + 1, y].CanEnter())
                        availables.Add(maze[x + 1, y]);//Right
                    if (maze[x, y + 1].CanEnter())
                        availables.Add(maze[x, y + 1]);//Down
                    break;

                case Direction.Up:
                    if (maze[x + 1, y].CanEnter())
                        availables.Add(maze[x + 1, y]);//Right
                    if (maze[x, y - 1].CanEnter())
                        availables.Add(maze[x, y - 1]);//Up
                    if (maze[x - 1, y].CanEnter())
                        availables.Add(maze[x - 1, y]);//Left
                    break;

                case Direction.Down:
                    if (maze[x - 1, y].CanEnter())
                        availables.Add(maze[x - 1, y]);//Left
                    if (maze[x, y + 1].CanEnter())
                        availables.Add(maze[x, y + 1]);//Down
                    if (maze[x + 1, y].CanEnter())
                        availables.Add(maze[x + 1, y]);//Right
                    break;
            }
            return availables;
        }

        /// <summary>
        /// This method will check each tile to see 
        /// if there is a pellet or an energizer 
        /// still in the maze, if there is pacmanWon 
        /// event is fired.
        /// </summary>
        public void CheckMembersLeft()
        {
            bool left = true;
            foreach(Path tile in maze)
            {
                if(!(tile.IsEmpty()))
                    left = false;
                    break;
            }
            if(left)
                PacmanWon?.Invoke();
        }
    }
}
