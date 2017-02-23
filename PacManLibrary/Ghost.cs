using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;

namespace PacManLibrary
{
    /// <summary>
    /// The ghost class contains the code for the ghost class. thecurrentState IGhostState field is used to determine which classes move method to use. 
    /// </summary>
    public class Ghost : IMovable
    {

        //field declarations
        private Direction direction;
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Color color;
        private IGhostState currentState;
        private Timer scared;

        //property declarations
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
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }
        public IGhostState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }


        /// <summary>
        /// Constructor for the ghost to instanciate its position, state, target and colour
        /// </summary>
        /// <param name="g">gamestate object</param>
        /// <param name="x">X coordinate for the ghost</param>
        /// <param name="y">Y coordinate for the ghost</param>
        /// <param name="target">target that the ghost will move towards</param>
        /// <param name="state">state that the ghost is in</param>
        /// <param name="color">colour that the ghost will be painted</param>
        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState state, Color color)
        {
            this.pacman = g.Pacman;
            Position = new Vector2(x, y);
            this.target = target;
            CurrentState = state;
            this.color = color;
        }
        /// <summary>
        /// Changes the ghosts current state
        /// </summary>
        /// <param name="state">iGhostState object to change the current state to</param>
        public void changeState(IGhostState state)
        {
            CurrentState = state;
        }
        /// <summary>
        /// calls the move method of the state that it currently is
        /// </summary>
        public void move()
        {
            CurrentState.move();
        }


        public void reset()
        {
            pen.AddToPen(this);
        }
    }
}
