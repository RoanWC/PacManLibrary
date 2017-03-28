using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacManLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacManGame
{
    class ScoreSprite : DrawableGameComponent
    {
        private bool pacmanWin = false;
        private bool gameover = false;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D imageGameOver;
        private Texture2D imagePacmanWon;
        private Game1 game;
        private GameState gs;
        public ScoreSprite(Game1 game, GameState gs)
            : base(game)
        {
            this.game = game;
            this.gs = gs;
        }

        public override void Initialize()
        {
            base.Initialize();
            gs.ScoreAndLives.GameOver += onGameEnded;
            gs.Maze.PacmanWon += onPacmanWin;
        }

        private void onGameEnded()
        {
            gameover = true;
        }

        private void onPacmanWin()
        {
            pacmanWin = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imageGameOver = game.Content.Load<Texture2D>("gameOver");
            imagePacmanWon = game.Content.Load<Texture2D>("Winner");
            font = game.Content.Load<SpriteFont>("scoreFont");//I dont know where this scorefont comes from
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Your score is: " + gs.ScoreAndLives.Score, new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(font, "You have : " + gs.ScoreAndLives.Lives+" Lives", new Vector2(0, 15), Color.Black);
            if (gameover)
            {

               // spriteBatch.DrawString(font, "You lost", new Vector2(50, 50), Color.White);
                 spriteBatch.Draw(imageGameOver, new Vector2(0,0), Color.Red);


            }
            if (pacmanWin)
            {
                //spriteBatch.DrawString(font, "You win ", new Vector2(50, 50), Color.White);
                spriteBatch.Draw(imagePacmanWon, new Vector2(0, 0), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
