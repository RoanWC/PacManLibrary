using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public class Scared : IGhostState
    {
        private Ghost ghost;
        private Maze maze;

        public Scared(Ghost ghost, Maze maze)
        {
            this.ghost = ghost;
            this.maze = maze;
        }
        public void move()
        {

        }
    }
}
