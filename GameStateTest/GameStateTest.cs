using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;


namespace GameStateTest
{
    [TestClass]
    public class GameStateTest
    {
        [TestMethod]
        public void ParseTest()
        {
            //arrange 
           GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            // expected w 
            Tile w = gs.Maze[5,2];
            Tile x = gs.Maze[11,11];
            Tile one = gs.Maze[11,8];
            Tile two = gs.Maze[9,10];
            Tile three = gs.Maze[10,10];
            Tile four = gs.Maze[11,10];
            Tile pacman = gs.Maze[17, 10];


            
            //act 

            

            //assert
            Assert.AreEqual(w, "w");

        }
        [TestMethod]
        public void TestPellet(){
            //arrange 
            Pellet p = new Pellet();
            int points = p.Points;
            
        }
        [TestMethod]
        public void TestEnergizer(){
            //arrange 
            GhostPack ghosts = new GhostPack();
            Energizer e = new Energizer(ghosts);
            int points = e.Points;
        }
        [TestMethod]
        public void TestScoreAndLives(){
             GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            ScoreAndLives sc = new ScoreAndLives(gs);
            Pellet p = new Pellet();           

            // make pacman die and check life
            gs.Pacman.PacManDies();
            // make pacman collide and check points
            sc.incrementScore(p);

            int lives = sc.Lives;
            int score = sc.Score;
            
            Assert.Expected(10, score);

        }
    }
}
