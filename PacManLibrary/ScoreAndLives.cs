
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    public class ScoreAndLives
    {
        private int lives;
        private int score;

        public ScoreAndLives(GameState gs)
        {

        }

        //events here

        public int Lives
        {
            get { return lives; }
            private set { lives = value; }
        }
        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        // event handlers here
    }
}
