using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    //public delegate void CollisionHander(int points);
    public class Pellet : ICollidable
    {
        private int points;

        public event CollisionHandler Collision;
        public int Points
        {
            get { return points; }
           // set { points = value; }
        }
        public void Collide()
        {
            this.points += 10;
            onCollision(this);

        }
        protected virtual void onCollision(ICollidable pellet)
        {
            if (Collision != null)
                Collision(pellet);
            //firing event.. ScoreAndLive's incremenetScore method will be called and passed onto it the pellet object
        }

 
    }
}
