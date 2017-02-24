﻿
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

        // event

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
        
        protected virtual void incrementScore(int points)
        {
            this.score += points;
        } 

    }
}
