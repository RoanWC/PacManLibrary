using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public enum GhostState
    {
        scared,
        chase,
        released,
        penned
    };
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    public delegate void CollisionHandler(ICollidable obj);
    public delegate void DeadPacManHandler();
    public delegate void PacmanWonHandler();
}
