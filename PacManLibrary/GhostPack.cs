using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PacManLibrary;

namespace PacManLibrary
{
    /// <summary>
    /// The GhostPack class centralizes where ghosts are asked to move, colliion 
    /// checks and reseting them back to the pen. It also changes them scared state.
    /// </summary>
    public class GhostPack
    {
        //List of ghosts
        private List<Ghost> ghosts;
        public List<Ghost> Ghosts
        {
            get;
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
        public bool CheckCollideGhosts(Vector2 target)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// resets the ghosts back to the pen when pacman has been eaten.
        /// </summary>
        public void ResetGhost()
        {

        }
        /// <summary>
        /// changes the state of the ghosts to scared
        /// </summary>
        public void scaredGhost()
        {

        }
        /// <summary>
        /// tells all the ghosts to move
        /// </summary>
        public void move()
        {

        }
        /// <summary>
        /// adds a ghost to the list
        /// </summary>
        /// <param name="g">ghost to be added to the list</param>
        public void Add(Ghost g)
        {
            Ghosts.Add(g);

        }
    }
}
