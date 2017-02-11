using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
    public class Chase : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        private Pacman pacman;
        private Vector2 target;

        public Chase(Ghost ghost, Maze maze, Vector2 target, Pacman pacman)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.pacman = pacman;
            this.target = target;
        }

        public void move()
        {
            throw new NotImplementedException();
        }
    }
}
