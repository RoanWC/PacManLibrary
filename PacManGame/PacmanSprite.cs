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
        private Pacman pacman;
        private SpriteBatch spriteBatch;
        private Texture2D imagePacman;
        private Game1 game;

        // keyboard input 
        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public PacmanSprite(Game1 game) : base(game)
        {
            this.game = game;
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
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            checkInput();
            base.Update(gameTime);
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    pacman.Move(Direction.Right);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        pacman.Move(Direction.Right);
                }
            }

            else if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    pacman.Move(Direction.Left);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        pacman.Move(Direction.Left);
                }
            }

            else if (newState.IsKeyDown(Keys.Up))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    pacman.Move(Direction.Up);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        pacman.Move(Direction.Up);
                }
            }

            else if (newState.IsKeyDown(Keys.Down))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    pacman.Move(Direction.Down);
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        pacman.Move(Direction.Down);
                }
            }

            // Once finished checking all keys, update old state.
            oldState = newState;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");

            spriteBatch.Draw(imagePacman, new Rectangle((int)pacman.PacManPosition.X * 32, (int)pacman.PacManPosition.Y * 32, 32, 32), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
