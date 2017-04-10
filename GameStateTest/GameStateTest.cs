using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;
//using System.IO;

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
        
            gs = GameState.Parse("@Files/levels.txt");
            Maze m = gs.Maze;

            // use to make sure pacman is in the right position
            Vector2 expectedPacmanPosition = new Vector2(11, 17);
            Vector2 actualPacmanPosition = new Vector2(gs.Pacman.PacManPosition.X, gs.Pacman.PacManPosition.Y);

            Console.WriteLine(m[2, 0].GetType());
            Console.WriteLine(m[9, 10].Member());

            // assert
            Assert.IsTrue(m[2, 0] is Wall);
            Assert.IsTrue(m[3, 1] is Path);
            Assert.IsTrue(m[21, 17].Member() is Energizer);
            Assert.IsTrue(m[9, 10].IsEmpty());
            Assert.IsFalse(m[1, 2].Member() is Energizer);
            Assert.IsTrue(m[9, 10] is Path);
            //ghost 1
            Assert.IsTrue(m[11, 8] is Path);
            // ghost 2
            Assert.IsTrue(m[10, 10] is Path);
            //ghost 3
            Assert.IsTrue(m[11, 10] is Path);
            // ghost 4
            Assert.IsTrue(m[12, 10] is Path);
            // PacMan
            Assert.IsTrue(m[11, 17] is Path);
            Assert.AreEqual(expectedPacmanPosition, actualPacmanPosition);
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
        
        [TestMethod]
        public void TestScoreAndLives(){

            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            ScoreAndLives sc = new ScoreAndLives(gs);
            bool dead = false;
            GhostPack ghosts = new GhostPack();
         
            Pellet p = new Pellet();
            Energizer e = new Energizer(ghosts);

            sc.GameOver += delegate () { dead = true; };
            // make pacman collide and check points
            sc.incrementScore(p);
  
            Assert.AreEqual(sc.Score, 10);
            sc.incrementScore(e);
            Assert.AreEqual(sc.Score, 110);

            // before pacman's death
            Assert.AreEqual(sc.Lives, 3);
            sc.deadPacman();
            // after 1st pacman's death
            Assert.AreEqual(sc.Lives, 2);
            // pacman still has one life
            Assert.IsFalse(dead);
            // pacman's second death
            sc.deadPacman();
            Assert.AreEqual(sc.Lives, 1);
            // event should fire after the last life gets lost
            sc.deadPacman();
            Assert.IsTrue(dead);
          
        }
    }
}
