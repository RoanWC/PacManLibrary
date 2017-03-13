using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;


namespace GameStateTest
{
    [TestClass]
    public class GhostTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            //arange
            GameState gs = new GameState();
            
            Vector2 target = new Vector2(2, 2);

            //act
            Ghost ghost = new Ghost(gs, 5, 5, target, GhostState.chase, Color.Red);

            //assert
            Assert.AreEqual(ghost.Color, Color.Red);
        }
        [TestMethod]
        public void testChangeStateReleased()
        {
            //arange
            GameState gs = new GameState();
            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack[1];

        }

        [TestMethod]
        public void testChangeStatePenned()
        {

        }
        [TestMethod]
        public void testChangeStateChase()
        {

        }

        
        [TestMethod]
        public void testTest()
        {
            //arrange
            int x = 10;

            //act
            x = x + 5;
            

            //assert
            Assert.AreEqual(15, x);
        }
    }
}
