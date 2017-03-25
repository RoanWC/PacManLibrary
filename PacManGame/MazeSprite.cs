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
    class MazeSprite : DrawableGameComponent
    {
        private Maze maze;
        // to render
        private SpriteBatch spriteBatch;
        private Texture2D imageEmpty;
        private Texture2D imageEnergizer;
        private Texture2D imageGhost;
        private Texture2D imagePacman;
        private Texture2D imagePellet;
        private Texture2D imageWall;
        private Game1 game;


        public MazeSprite(Game1 game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
              imageEmpty = game.Content.Load<Texture2D>("empty");
              imageEnergizer = game.Content.Load<Texture2D>("energizer");
              imageGhost = game.Content.Load<Texture2D>("ghost");
              imagePacman = game.Content.Load<Texture2D>("pacman");
              imagePellet = game.Content.Load<Texture2D>("pellet");
              imageWall = game.Content.Load<Texture2D>("wall");

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");


            for (int i = 0; i < gs.Maze.Size; i++)
            {
                for (int j = 0; j < gs.Maze.Size; j++)
                {
                    var tile = gs.Maze[j, i];

                    if (tile is Wall)
                    {
                        spriteBatch.Draw(imageWall, new Rectangle(j * 32, i * 32, 32, 32), Color.White);
                    }
                    else if(tile is Path)
                    {
                        if(tile.Member() is Energizer)                       
                            spriteBatch.Draw(imageEnergizer, new Rectangle(j * 32, i * 32, 32, 32), Color.White);
                        
                        else if(tile.Member() is Pellet)
                            spriteBatch.Draw(imagePellet, new Rectangle(j * 32, i * 32, 32, 32), Color.White);

                        else if(tile.IsEmpty())                           
                            spriteBatch.Draw(imageEmpty, new Rectangle(j * 32, i * 32, 32, 32), Color.White);
                    }
          
                }
            }
            spriteBatch.End(); 
            base.Draw(gameTime);
        }
    }
}
