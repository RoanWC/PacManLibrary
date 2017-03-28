using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PacManLibrary;

namespace PacManGame
{
    class PacmanSprite : DrawableGameComponent
    {
        private GameState gs;
        private SpriteBatch spriteBatch;
        private Texture2D imagePacman;
        private Texture2D imagePacmanUp;
        private Texture2D imagePacmanDown;
        private Texture2D imagePacmanLeft;
        private Texture2D imagePacmanRight;
        private Game1 game;
      



        // keyboard input 
        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public PacmanSprite(Game1 game, GameState gs) : base(game)
        {
            this.game = game;
            this.gs = gs;
            counter = 0;
            threshold = 5;
        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 6;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imagePacman = game.Content.Load<Texture2D>("pacman");
          //  imagePacmanDown = game.Content.Load<Texture2D>("pacmanDOWN");
         //   imagePacmanLeft = game.Content.Load<Texture2D>("pacmanLEFT");
         //   imagePacmanRight = game.Content.Load<Texture2D>("pacmanRIGHT");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (gs.ScoreAndLives.Lives == 0)
            {
                
            }         
                counter++;
                if (threshold == counter)
                {
                    checkInput();
                    base.Update(gameTime);
                    counter = 0;
                }
            
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    gs.Pacman.Move(Direction.Right);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        gs.Pacman.Move(Direction.Right);
                }
            }

            else if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    gs.Pacman.Move(Direction.Left);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        gs.Pacman.Move(Direction.Left);
                }
            }

            else if (newState.IsKeyDown(Keys.Up))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    gs.Pacman.Move(Direction.Up);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        gs.Pacman.Move(Direction.Up);
                }
            }

            else if (newState.IsKeyDown(Keys.Down))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    gs.Pacman.Move(Direction.Down);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        gs.Pacman.Move(Direction.Down);
                }
            }
        
            // Once finished checking all keys, update old state.
            oldState = newState;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
           // var origin = new Vector2(imagePacman.Width, imagePacman.Height);
            //spriteBatch.Draw(imagePacman, new Rectangle((int)gs.Pacman.PacManPosition.X * 32, (int)gs.Pacman.PacManPosition.Y * 32, 32, 32),null, Color.White,2.99f,origin, SpriteEffects.None, 0f);
            spriteBatch.Draw(imagePacman, new Rectangle((int)gs.Pacman.PacManPosition.X * 32, (int)gs.Pacman.PacManPosition.Y * 32, 32, 32), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
