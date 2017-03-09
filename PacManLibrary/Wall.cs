﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y)
        {
        }

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
