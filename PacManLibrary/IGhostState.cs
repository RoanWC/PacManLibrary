using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{

    public interface IGhostState
    {
        void Move();
        void Collide();


        event CollisionHandler Collision;
    }
}
