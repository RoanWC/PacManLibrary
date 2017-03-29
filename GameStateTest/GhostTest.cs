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
        public void testChangeStateReleased()
        {
            //arange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");

            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.released);

            //assert
            Assert.IsTrue(ghost.CurrentState is Chase);
        }

        [TestMethod]
        public void testChangeStatePenned()
        {
            //arange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");

            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.penned);

            //assert
            Assert.IsTrue(ghost.CurrentState is Penned);
        }
        [TestMethod]
        public void testChangeStateChase()
        {
            //arange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");

            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.chase);

            //assert
            Assert.IsTrue(ghost.CurrentState is Chase);
        }

        [TestMethod]
        public void testChangeStateScared()
        {
            //arange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.scared);

            //assert
            Assert.IsTrue(ghost.CurrentState is Scared);
        }
       [TestMethod]
        public void testCollision()
        {
            //arange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");

            Ghost ghost = gs.Ghostpack.Ghosts[1];
            ghost.ChangeState(GhostState.scared);

            bool eventThrown = false;
            ghost.Collision += (obj) => { eventThrown = true; };
            //act
            gs.Pacman.PacManPosition = ghost.Position;
            ghost.CheckCollision();
            //assert
            Assert.IsTrue(eventThrown);

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
