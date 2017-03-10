using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Pacman
    {
        private GameState controller;
        private List<Ghost> ghosts;
        private Maze maze;
        private Vector2 position;


        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.ghosts = controller.Ghostpack.Ghosts;
            this.maze = controller.Maze;
        }
        public void Move(Direction dir)
        {
           List<Tile> availableTiles = maze.GetAvailableNeighbours(PacManPosition, dir);
            int x = (int)PacManPosition.X;
            int y = (int)PacManPosition.Y;

                switch (dir)
                {
                    case Direction.Up:
                        if (availableTiles.Contains(maze[x, y - 1]))                       
                            PacManPosition = new Vector2(x, y - 1);
                        
                        break;

                    case Direction.Down:
                        if (availableTiles.Contains(maze[x, y + 1]))
                            PacManPosition = new Vector2(x, y + 1);
                        
                        break;

                    case Direction.Left:
                        if (availableTiles.Contains(maze[x - 1, y]))
                            PacManPosition = new Vector2(x - 1, y);
                        
                        break;

                   case Direction.Right:
                        if (availableTiles.Contains(maze[x + 1, y]))                      
                            PacManPosition = new Vector2(x + 1, y);
                                           
                        break;            
            }
        }
        public Vector2 PacManPosition
        {
            get { return this.position; }
            set { position = value; }
        }
        public void CheckCollisions()
        {
            if (!(maze[(int)position.X, (int)position.Y].IsEmpty()))
                maze[(int)position.X, (int)position.Y].Collide();

            foreach(Ghost ghost in ghosts)
            {
                ghost.CheckCollision();
            }
            
        }       
    }
}
