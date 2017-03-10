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
        private int points = 100;
        private GhostPack ghosts;

        public event CollisionHandler Collision;

        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts;  
        }
        public int Points
        {
            get { return this.points; }
        }
        public void Collide()
        {
            if (Collision != null)
                Collision(this);
        }
    }
}
