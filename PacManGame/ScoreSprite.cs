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
        private SpriteBatch spriteBatch;
        private SpriteFont font;
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
            gs.ScoreAndLives.GameOver += gameEnded;
        }

        private void gameEnded()
        {
            Console.WriteLine("You dead!");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            spriteBatch.DrawString(font, "Your score is: " + gs.ScoreAndLives.Score, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, "\nYou have : " + gs.ScoreAndLives.Lives+" Lives", new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
