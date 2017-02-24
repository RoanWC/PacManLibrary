using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Path : Tile
    {
        public Path(int x, int y, ICollidable member = null) : base(x,y)
        {
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
