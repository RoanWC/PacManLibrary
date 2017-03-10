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
        public event PacmanWonHandler PacmanWon;

        public Maze()
        {
            //base(x)
            //Still working on this one, dont think it works
            //maze = new Tile[maze.GetLength(0),maze.GetLength(1)];
        }
        public void SetTiles(Tile[,] tile)
        {
            this.maze = tile;
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

        //Dont think this worked
        public int Size
        {
            get { return maze.GetLength(0); }
        }

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
                    if (maze[x, y + 1].CanEnter())
                        availables.Add(maze[x, y + 1]);//Down
                    if (maze[x - 1, y].CanEnter())
                        availables.Add(maze[x - 1, y]);//Left
                    break;

                case Direction.Down:
                    if (maze[x - 1, y].CanEnter())
                        availables.Add(maze[x - 1, y]);//Left
                    if (maze[x, y-1].CanEnter())
                        availables.Add(maze[x, y - 1]);//Up
                    if (maze[x + 1, y].CanEnter())
                        availables.Add(maze[x + 1, y]);//Right
                    break;
            }
            return availables;
        }

        //There has to be a more efficient way to get this done but at the moment this is the only
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
