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
        private Maze maze;


        public Pacman(GameState controller)
        {
            this.controller = controller;
        }
        public void Move(Direction dir)
        {
            dir += 1;
        }
        public void CheckCollisions()
        {

        }
        

    }
}
