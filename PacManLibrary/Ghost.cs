using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;

namespace PacManLibrary
{
    public class Ghost : IMovable
    {
        public Delegate ghostState;

        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        
        private Color color;
        private IGhostState currentState;
        private Timer scared;
        public Vector2 Position
        {
            get
            {
                return Position;
            }
            set
            {
                this.Position = value;
            }
        }
        public Direction direction
        {
            get;
            set;
        }

        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState state, Color color)
        {
            this.pacman = g.Pacman;
            Position = new Vector2(x, y);
            this.target = target;
            currentState = state;
            this.color = color;

        }
        public void changeState(IGhostState state)
        {

        }


        public void move()
        {
            throw new NotImplementedException();
        }
    }
}
