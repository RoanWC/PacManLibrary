using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PacManLibrary;

namespace PacManGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

       private MazeSprite mazeSprite;
       private PacmanSprite pacmanSprite;
        private GhostsSprite ghostsSprite;
        private GameState gs;
        private ScoreSprite scoreSprite;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gs = new GameState();
            gs = GameState.Parse("levels.txt");


            mazeSprite = new MazeSprite(this, gs);
            pacmanSprite = new PacmanSprite(this, gs);
            ghostsSprite = new GhostsSprite(this, gs);
            scoreSprite = new ScoreSprite(this, gs);
            Components.Add(mazeSprite);
            Components.Add(pacmanSprite);
            Components.Add(ghostsSprite);
            Components.Add(scoreSprite);
            gs.ScoreAndLives.GameOver += gameEnded;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            graphics.PreferredBackBufferHeight = 750;
            graphics.PreferredBackBufferWidth = 750;
            graphics.ApplyChanges();


            base.Draw(gameTime);
        }
        private void gameEnded()
        {
            Components.Remove(pacmanSprite); //the ball won�t be updated or drawn any more
        }


    }
}
