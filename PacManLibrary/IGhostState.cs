using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public enum GhostState
    {
        scared,
        chase,
        released,
        penned
    };
    public interface IGhostState
    {
        void move();

    }
}
