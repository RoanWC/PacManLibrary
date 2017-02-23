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
        private Direction direction;
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
        public Direction Direction
        {
            get;
            set;
        }
        /// <summary>
        /// Constructor for the ghost to instanciate its position, state, target and colour
        /// </summary>
        /// <param name="g">gamestate object</param>
        /// <param name="x">X coordinate for the ghost</param>
        /// <param name="y">Y coordinate for the ghost</param>
        /// <param name="target">target that the ghost will move towards</param>
        /// <param name="state">state that the ghost is in</param>
        /// <param name="color">colour that the ghost will be</param>
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
