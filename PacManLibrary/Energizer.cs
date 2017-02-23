using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Energizer : ICollidable
    {
        private int points;
        private GhostPack ghosts;


        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts; 
        }
        public int Points
        {
            get { return points; }
        }
        public void Collide()
        {
            this.points += 100;
            this.ghosts.scaredGhost();
        }
    }
}
