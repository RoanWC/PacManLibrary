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
        private GhostPack ghosts;
        private Ghost ghost1; 
        private Maze maze;


        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.ghosts = controller.Ghostpack;
        }
        public void Move(Direction dir)
        {
            // look at scared.cs
        }
        public void CheckCollisions()
        {
            // get the position of each ghost to check if it collided with 
            // the current pacman position.
            if (controller.Ghostpack == )
        }       
    }
}
