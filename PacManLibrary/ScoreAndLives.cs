
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
     /// <summary>
     /// This class is responsible to keep track of the score and lives 
     /// of the game. 
     /// </summary>
    public class ScoreAndLives
    {
        private int lives;
        private int score;
        public event DeadPacManHandler GameOver;
        
        /// <summary>
        /// This constructor gets passed to it a gamestate and uses it
        /// to initialize its private fields. 
        /// </summary>
        /// <param name="gs"></param>
        public ScoreAndLives(GameState gs)
        {
            lives = 3;
            score = 0;
        }
         /// <summary>
        /// Property which returns or sets the total amount of lives the pacman has. 
        /// </summary>
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
         /// <summary>
        /// Property which returns or sets the score of the game.
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

         /// <summary>
        /// This event handler launches the gameover event when pacman does 
        /// not have any more lives, otherwise it decrement the life by one. 
        /// </summary>
        public virtual void deadPacman()
        {
            this.lives -= 1;

            if (this.lives == 0)
                onGameOver();
        } 

        protected virtual void onGameOver()
        {           
            GameOver();
        }




        /// <summary>
        /// This method increments the score of the game depending on 
        /// the ICollidable object which got passed onto it when the collide 
        /// event gets launched. 
        /// </summary>  
            /// <param name="obj"></param>     
        public void incrementScore(ICollidable obj)
        {
            //getting the points of the ICollidable object to increment
            this.score += obj.Points;
   
        } 

    }
}
