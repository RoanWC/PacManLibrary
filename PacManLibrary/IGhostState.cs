using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// deffines the interface for the IGhostState
    /// </summary>
    public interface IGhostState
    {
        void Move();
        void Collide();


        event CollisionHandler Collision;
    }
}
