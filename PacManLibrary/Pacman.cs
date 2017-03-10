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
