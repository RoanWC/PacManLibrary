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

            //act 
            Tile w = gs.Maze[5, 2];
            Tile x = gs.Maze[11, 11];
            Tile one = gs.Maze[11, 8];
            Tile two = gs.Maze[9, 10];
            Tile three = gs.Maze[10, 10];
            Tile four = gs.Maze[11, 10];
            Tile pacman = gs.Maze[17, 10];

            //assert
            Assert.AreEqual(w, "w");
            Assert.AreEqual(x, "x");
            Assert.AreEqual(one, "1");
            Assert.AreEqual(two, "2");
            Assert.AreEqual(three, "3");
            Assert.AreEqual(four, "4");
            Assert.AreEqual(pacman, "P");

        }
        [TestMethod]
        public void TestPellet(){
            //arrange 
            Pellet p = new Pellet();
            int points = p.Points;

            Assert.AreEqual(points, 10);
            
        }
        [TestMethod]
        public void TestEnergizer(){
            //arrange 
            GhostPack ghosts = new GhostPack();
            Energizer e = new Energizer(ghosts);
            int points = e.Points;

            Assert.AreEqual(points, 100);
        }
        /*
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
            
            Assert.AreEqual(score, 10);

        }*/
    }
}
