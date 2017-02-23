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
        private Vector2 position;
        private Maze maze;


        public Pacman(GameState controller, int x, int y)
        {
            this.controller = controller;
            this.ghosts = controller.Ghostpack.Ghosts;
            this.position = new Vector2(x,y);
        }
        public void Move(Direction dir)
        {
            // look at scared.cs
        }
        public Vector2 PacManPosition
        {
            get { return this.position; }
        }
        public void CheckCollisions()
        {
            // check collision with all the other objects on the maze
             for(int i = 0; i < this.ghosts.Count; i++)
            {
                if (ghosts[i].Position == this.position)
                {
                    this.controller.Score.Lives -= 1;
                }
               
            }
        }       
    }
}
