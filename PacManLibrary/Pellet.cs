using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;



namespace PacManLibrary
{
        /// <summary>
        /// This class inherits from ICollidable and is a pellet
        /// object in a tile. 
        /// </summary>
    public class Pellet : ICollidable
    {
        private int points = 10;

        public event CollisionHandler Collision;
        /// <summary>
        /// Property which returns the amount of points that a pellet gives.
        /// </summary>
        public int Points
        {
            get { return this.points; }
        }
         /// <summary>
        /// Whenever this method gets called, the collision event of 
        /// the pellet gets launched. 
        /// </summary>
        public void Collide()
        {
           if (Collision != null)
                Collision(this);
        }
  

 
    }
}
