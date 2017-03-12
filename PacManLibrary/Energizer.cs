using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
     /// <summary>
     /// This class inherits from ICollidable and is an Energizer
     /// object in a tile. 
     /// </summary>
    public class Energizer : ICollidable
    {
        private int points = 100;
        private GhostPack ghosts;
        // Collision event of the energizer
        public event CollisionHandler Collision;

        /// <summary>
        /// Constructor setting the ghosts pack.
        /// </summary>
        /// <param name="ghosts"></param>
        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts;  
        }
        /// <summary>
        /// Property which returns the amount of points that a energizer gives.
        /// </summary>
        public int Points
        {
            get { return this.points; }
        }
        /// <summary>
        /// Whenever pacman collides with an energizer, the ghosts enter 
        /// scare mode and the collision event of 
        /// the energizer gets launched. 
        /// </summary>
        public void Collide()
        {
            ghosts.ScareGhost();          
            if (Collision != null)
                Collision(this);
        }
    }
}
