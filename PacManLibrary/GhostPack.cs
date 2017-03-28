using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The GhostPack class centralizes where ghosts are asked to move, colliion 
    /// checks and reseting them back to the pen. It also changes them scared state.
    /// </summary>
    public class GhostPack : IEnumerable<Ghost>
    {
        //List of ghosts
        private List<Ghost> ghosts;
        public List<Ghost> Ghosts
        {
            get { return ghosts; }
            set { ghosts = value; }
        }
        public Vector2 ResetLocation
        {
            get;
            set;
        }
        /// <summary>
        /// Constructor to initialize the ghostList
        /// </summary>
        public GhostPack()
        {
            Ghosts = new List<Ghost>();
        }
        /// <summary>
        /// checks if the Ghosts have colided with pacman
        /// </summary>
        /// <param name="target">contains the coordinates for pacman</param>
        /// <returns>returns true if the ghost has colided with pacman</returns>
        public void CheckCollision()
        {
            foreach (Ghost g in ghosts)
            {
                g.CheckCollision();
            }
        }
        /// <summary>
        /// resets the ghosts back to the pen when pacman has been eaten.
        /// </summary>
        public void ResetGhost()
        {
            foreach (Ghost g in ghosts)
            {
                if(g.CurrentState != g.gStates[GhostState.penned])
                    g.Reset(g);
            }
        }
        /// <summary>
        /// changes the state of the ghosts to scared
        /// </summary>
        public void ScareGhost()
        {
            
            foreach (Ghost g in ghosts)
            {
                g.ChangeState(GhostState.scared);
            }
        }


        /// <summary>
        /// tells all the ghosts to move
        /// </summary>
        public void Move()
        {
            foreach (Ghost g in ghosts)
            {
                g.Move();
            }
        }
        /// <summary>
        /// adds a ghost to the list
        /// </summary>
        /// <param name="g">ghost to be added to the list</param>
        public void Add(Ghost g)
        {
            ghosts.Add(g);
        }

        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
        public void setReleaseLocation()
        {
            foreach(Ghost g in ghosts)
            {
                g.ResetLocation = ResetLocation;
            }
        }
    }
}
