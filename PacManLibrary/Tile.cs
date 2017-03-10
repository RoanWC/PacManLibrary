using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The Tile class is the base for what will be walls and paths.
    /// This abstract Tile class will declare what we expect walls 
    /// and paths to be able to do at the basic level.
    /// </summary>
    public abstract class Tile
    {
        private Vector2 vector;

        /// <summary>
        /// This is the tile constructor that takes x and y
        /// as parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tile(int x, int y)
        {
            vector.X = x;
            vector.Y = y;
        }

        /// <summary>
        /// This property is to get and set the position of any 
        /// given tile, returning a vector.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return vector;
            }
            set
            {
                vector = value;
            }
        }
        /// <summary>
        /// This method will return the ICollidable member that 
        /// is in a tile
        /// </summary>
        /// <returns>ICollidable</returns>
        public abstract ICollidable Member();

        /// <summary>
        /// The purpose of this is to return a boolean specifying 
        /// whether the derived tile can be entered.
        /// </summary>
        /// <returns>bool</returns>
        public abstract bool CanEnter();

        /// <summary>
        /// This method will only be implemented in the path,
        /// it will be used the invoke collide on the member in
        /// the path.
        /// </summary>
        public abstract void Collide();

        /// <summary>
        /// This method is intended to check if the tile 
        /// contains a member in a derived class.
        /// </summary>
        /// <returns>bool</returns>
        public abstract bool IsEmpty();

        /// <summary>
        /// This method invokes the Distance method to calculate 
        /// the distance between 2 vectors, returning the distance
        /// as a float.
        /// </summary>
        /// <param name="goal"></param>
        /// <returns>float</returns>
        public float GetDistance(Vector2 goal)
        {
            return Vector2.Distance(vector, goal);
        }
    }
}
