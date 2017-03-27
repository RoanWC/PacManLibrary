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
    class GhostsSprite : DrawableGameComponent
    {
        private GameState gs;
        private SpriteBatch spriteBatch;
        private Texture2D ghostImage;
        private Game1 game;
        int moveCounter = 0;
        int framesDesired = 15;

        public GhostsSprite(Game1 game,GameState gs)
            : base(game)
        {
            this.game = game;
            this.gs = gs;
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ghostImage = game.Content.Load<Texture2D>("ghost");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            moveCounter++;
            if(moveCounter == framesDesired)
            {
                gs.Ghostpack.Move();
                moveCounter = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            foreach (Ghost g in gs.Ghostpack)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * 32, (int)g.Position.Y * 32, 32, 32), g.Color);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

    }
}
