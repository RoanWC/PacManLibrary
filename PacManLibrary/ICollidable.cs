using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{ 
    public interface ICollidable
    {
        // CollisionHandler is the delegate and Collision is the event 
        event CollisionHandler Collision;
         int Points
        {
            get;
        }
        void Collide();
    }
}
