using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public enum ghostState
    {
        ScaredState,
        Chasestate
    };
    public interface IGhostState
    {
        void move();

    }
}
