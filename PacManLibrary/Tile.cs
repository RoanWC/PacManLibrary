using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public abstract class Tile
    {
        public void tile(int x, int y)
        {
            //Not 100% sure about this because you cant use the newly created vector.
            Vector2 vector;
            vector.X = x;
            vector.Y = y;
        }

        public Vector2 Position()
        {
            //What is the point of a position of a tile?
            return new;
        }

        public abstract ICollidable Member();
        public abstract bool CanEnter();
        public abstract void Collide();
        public abstract bool IsEmpty();
        public float GetDistance(Vector2 goal)
        {
            //Get the distance for what exactly? Between what?
        }
    }
}
