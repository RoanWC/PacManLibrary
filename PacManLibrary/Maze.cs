using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Maze : Tile
    {
        private Tile[,] maze;

        public Maze()
        {
            //Still working on this one
            maze = new Tile[(int)tilePosition.X, (int)tilePosition.Y];
        }
        public Tile this[int index1, int indexer2]
        {
            get
            {
                return maze[index1, indexer2];
            }

            set
            {
                maze[index1, indexer2] = value;
            }
        }

        public override bool CanEnter()
        {
            throw new NotImplementedException();
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
