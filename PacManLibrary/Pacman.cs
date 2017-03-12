﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
       /// <summary>
        /// This class is reponsible for the PacMan object. It 
        /// moves Pacman and checks for collision with other objects.
        /// </summary>
    public class Pacman
    {
        private GameState controller;
        private List<Ghost> ghosts;
        private Maze maze;
        private Vector2 position;

        /// <summary>
        /// This constructor gets passed to it a gamestate and initializes all 
        /// the private fields.
        /// </summary>
        /// <param name="controller"></param>
        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.ghosts = controller.Ghostpack.Ghosts;
            this.maze = controller.Maze;
        }
        /// <summary>
        /// This method gets passed to it a direction and moves the pacman 
        /// depending on the direction of which the user has chosen. To do so, 
        /// it looks for the available tiles for which pacman will be able 
        /// to move into. 
        /// </summary>
        /// <param name="dir"></param>
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
         /// <summary>
        /// Property which returns or sets a Vector2 of pacman's position.
        /// </summary>
        public Vector2 PacManPosition
        {
            get { return this.position; }
            set { position = value; }
        }
         /// <summary>
        /// This method checks if pacman collides with any other 
        /// as it moves. 
        /// </summary>
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
