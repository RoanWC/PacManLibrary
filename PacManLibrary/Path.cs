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
        private int x;
        private int y;
        private ICollidable member;
        public Path(int x, int y, ICollidable member = null) : base(x,y)
        {
            this.x = x;
            this.y = y;
            this.member = member;
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Collide()
        {
            member.Collide();
        }

        public override bool IsEmpty()
        {
            if(member is Pellet || member is Energizer ||
                member is Ghost)
                return false;
            return true;
        }

        public override ICollidable Member()
        {
            return member;
        }
    }
}
