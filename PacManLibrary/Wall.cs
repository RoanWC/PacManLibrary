using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// Wall is a derived class of tile, this class 
    /// will represents all of the walls in the pacman
    /// game, so there is not much implementationfor 
    /// this class.
    /// </summary>
    public class Wall : Tile
    {

        /// <summary>
        /// The wall constructor calls the base constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Wall(int x, int y) : base(x, y)
        {
            
        }

        /// <summary>
        /// A wall cannot be entered so it will always 
        /// return false.
        /// </summary>
        /// <returns>bool</returns>
        public override bool CanEnter()
        {
            return false;
        }

        public override void Collide()
        {
            throw new NotImplementedException();
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override ICollidable Member()
        {
            throw new NotImplementedException();
        }
    }
}
