
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

        public event DeadPacManHandler GameOver;

        public ScoreAndLives(GameState gs)
        {
            lives = gs.ScoreAndLives.Lives;
            score = gs.ScoreAndLives.Score;
        }


        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        // event handlers here
        public virtual void deadPacman()
        {
            this.lives -= 1;
            if (this.lives == 0)
                GameOver();
        }        
        public void incrementScore(ICollidable obj)
        {
            //getting the points
            this.score += obj.Points;
   
        } 

    }
}
