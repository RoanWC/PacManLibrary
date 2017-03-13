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
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.released);

            //assert
            Assert.AreEqual(ghost.gStates[GhostState.chase], ghost.CurrentState);
        }

        [TestMethod]
        public void testChangeStatePenned()
        {
            //arange
            GameState gs = new GameState();
            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.penned);

            //assert
            Assert.AreEqual(ghost.gStates[GhostState.penned], ghost.CurrentState);
        }
        [TestMethod]
        public void testChangeStateChase()
        {
            //arange
            GameState gs = new GameState();
            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.chase);

            //assert
            Assert.AreEqual(ghost.gStates[GhostState.chase], ghost.CurrentState);
        }

        [TestMethod]
        public void testChangeStateScared()
        {
            //arange
            GameState gs = new GameState();
            Vector2 target = new Vector2(2, 2);
            Ghost ghost = gs.Ghostpack.Ghosts[1];

            //act
            ghost.ChangeState(GhostState.scared);

            //assert
            Assert.AreEqual(ghost.gStates[GhostState.scared], ghost.CurrentState);
        }
        [TestMethod]
        public void testCollision()
        {
            //arange
            GameState gs = new GameState();
            Ghost ghost = gs.Ghostpack.Ghosts[1];
            bool eventThrown = false;
            ghost.Collision +={ eventThrown = true };
            //act
            gs.Pacman.PacManPosition = ghost.Position;
            ghost.CheckCollision();


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
