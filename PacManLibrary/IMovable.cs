using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{


    public interface IMovable
    {

        Direction Direction
        {
            get;
            set;
        }

        Vector2 Position
        {
            get;
            set;
        }




        void move();


    }
}
