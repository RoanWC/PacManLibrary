using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Pellet : ICollidable
    {
        private int points;

        public event CollisionHandler Collision;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public void Collide()
        {
            this.points += 10;
        }

        protected virtual void OnCollision(int points)
        {
            Collision?.Invoke(points);
        }
    }
}
