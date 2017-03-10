using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;


namespace GameStateTest
{
    [TestClass]
    public class GameStateTest
    {
        [TestMethod]
        public void PelletTest()
        {
            Pellet p = new Pellet();
            

        }
        [TestMethod]
        public void ParseTest()
        {
            //arrange 
           GameState gs = new GameState();


            //act 

            gs = GameState.Parse(@"H:\levels.txt");

            //assert
            Assert.AreEqual("w", gs.Maze[0, 9]);
            Assert.AreEqual("P", gs.Maze[17, 11]);
            Assert.AreEqual("e", gs.Maze[17, 21]);
            Assert.AreEqual("m", gs.Maze[13, 9]);
            Assert.AreEqual("w", gs.Maze[0, 1]);

        }
      
    }
}
