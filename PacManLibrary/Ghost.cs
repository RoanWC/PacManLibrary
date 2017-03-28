using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Timers;


namespace PacManLibrary
{
    /// <summary>
    /// The ghost class contains the code for the ghost class. thecurrentState IGhostState field is used to determine which classes move method to use. 
    /// </summary>
    public class Ghost : IMovable,ICollidable
    {

        //field declarations
        private Pacman pacman;
        private Vector2 target;
        private Pen pen = new Pen();
        private Maze maze;
        private static Timer scaredtimer;
        public Dictionary<GhostState, IGhostState> gStates = new Dictionary<GhostState, IGhostState>(3);
        //private Tile resetLocation;
        private Vector2 resetLocation;
        private Color acctualColor;

        //property declarations
        public Vector2 Position { get; set; }
        public Direction Direction { get; set; }
        public IGhostState CurrentState { get; set; }
        public Color Color { get; set; }
        public Vector2 ResetLocation{get;set;}

        public int Points
        {
            get
            {
                return 200;
            }
        }

        //event declarations
        public event DeadPacManHandler PacManDies;
        public event CollisionHandler Collision;

        //event triggers
        protected virtual void OnPacManDies(ICollidable i)
        {
            PacManDies?.Invoke();
        }
        protected virtual void OnCollision(ICollidable i)
        {
            Collision?.Invoke(i);
        }

        static Ghost()
        {
            scaredtimer = new Timer();
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
        public Ghost(GameState g, int x, int y, Vector2 target, GhostState state, Color color)
        {
            maze = g.Maze;
            this.pacman = g.Pacman;
            CreateStates();
            Position = new Vector2(x, y);
            this.target = target;
            ChangeState(state);
            Color = color;
            acctualColor = color;
        }
        /// <summary>
        /// Changes the ghosts current state
        /// </summary>
        /// <param name="state">ghostState enum to determine what state to change to</param>
        public void ChangeState(GhostState state)
        {
            
            if (state == GhostState.released)
            {
                Position = ResetLocation;
                CurrentState =  gStates[GhostState.chase];
            }
            else
            {
                if(state == GhostState.scared)
                {
                    Color = Color.Blue;
                    scaredtimer.Interval = 5000;
                    scaredtimer.Enabled = true;
                    scaredtimer.Elapsed += ChangeToChase;
                }
                else
                {
                    Color = acctualColor;
                }
                CurrentState = gStates[state];
            }
        }
        public void ChangeToChase(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;
            this.ChangeState(GhostState.chase);
        }

        /// <summary>
        /// Calls the collide method of the ghosts current state.
        /// </summary>
        public void Collide()
        {
            CurrentState.Collide();
        }
        /// <summary>
        /// checks if the current ghost is on the same tile as pacman
        /// </summary>
        public void CheckCollision()
        {
            if(pacman.PacManPosition == Position)
            {
                Collide();
               // Reset();
            }
        }
        
        /// <summary>
        /// calls the move method of the state that it currently is
        /// </summary>
        public void Move()
        {
            CurrentState.Move();
        }

        /// <summary>
        /// resets the ghost back to the pen
        /// </summary>
        public void Reset(ICollidable obj)
        {
            pen.AddToPen(this);
        }
        
        
        /// <summary>
        /// creates the IghostState objects for all the possible states and puts them into a dictionary
        /// </summary>
        public void CreateStates()
        {
            IGhostState scaredState = new Scared(this, maze);
            gStates.Add(GhostState.scared, scaredState);
            scaredState.Collision += OnCollision;

            IGhostState chaseState = new Chase(this, maze, target, pacman);
            gStates.Add(GhostState.chase, chaseState);
            chaseState.Collision += OnPacManDies;
            

            IGhostState pennedState = new Penned(this, maze);
            gStates.Add(GhostState.penned, pennedState);
        }
       

    }
}
