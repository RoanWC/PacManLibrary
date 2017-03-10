using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The Path class is derived from tile with much of its 
    /// implementation supported. A path is a tile that can 
    /// be entered and can also hold different types of members.
    /// </summary>
    public class Path : Tile
    {
        private int x;
        private int y;
        private ICollidable member;

        /// <summary>
        /// The Path constructor calls the base constructor,
        /// and also takes an ICollidable member as a param.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="member"></param>
        public Path(int x, int y, ICollidable member = null) : base(x,y)
        {
            this.x = x;
            this.y = y;
            this.member = member;
        }
        /// <summary>
        /// This method will always return true because 
        /// a path will always be able to be entered.
        /// </summary>
        /// <returns>bool</returns>
        public override bool CanEnter()
        {
            return true;
        }

        /// <summary>
        /// This method calls the Collide method of 
        /// the member once a collision occurs.
        /// </summary>
        public override void Collide()
        {
            member.Collide();
        }

        /// <summary>
        /// The job of this method is to check if the path
        /// is empty or not. A path will be empty if there 
        /// is no ghost, pellet or energizer.
        /// </summary>
        /// <returns>bool</returns>
        public override bool IsEmpty()
        {
            if(member is Pellet || member is Energizer)
                return false;
            return true;
        }

        /// <summary>
        /// This method will return a member that can be 
        /// collided with.
        /// </summary>
        /// <returns></returns>
        public override ICollidable Member()
        {
            return member;
        }
    }
}
