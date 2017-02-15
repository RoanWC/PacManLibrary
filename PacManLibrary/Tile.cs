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
            this.x = x;
            this.y = y;
        }

        public Vector2 Position()
        {
            return;
        }

        public abstract ICollidable Member();
        public abstract bool CanEnter();
        public abstract void Collide();
        public abstract bool IsEmpty();
        public float GetDistance(Vector2 goal)
        {

        }
    }
}
