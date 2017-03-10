﻿using System;
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
        public event PacmanWonHandler PacmanWon;

        /// <summary>
        /// This is an empty constructor becasue setTiles is 
        /// responsible for setting all of the tiles.
        /// </summary>
        public Maze()
        {
            //base(x)
            //Still working on this one, dont think it works
            //maze = new Tile[maze.GetLength(0),maze.GetLength(1)];
        }
        /// <summary>
        /// This method takes in a 2d array of tiles and sets the maze 2d array 
        /// </summary>
        /// <param name="tile"></param>
        public void SetTiles(Tile[,] tile)
        {
            
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    maze[i, j] = tile[i, j];
                }
            }
        }

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
                   index1 >= Size || index2 >= Size)
                    throw new ArgumentOutOfRangeException("The indexes must be in range");
                maze[index1, index2] = value;
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
