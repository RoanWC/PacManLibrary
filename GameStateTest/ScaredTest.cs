using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using PacManLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateTest
{
    [TestClass]
    public class ScaredTest
    {
        [TestMethod]
        public void testMoveValid()
        {
            //arrange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            //act
            gs.Ghostpack.Ghosts[0].Move();
            //assert
            Assert.AreEqual(new Vector2(10, 8), gs.Ghostpack.Ghosts[0].Position);
        }
 
    }
}
/*
GameState gs = new GameState();
gs = GameState.Parse("levels.txt");

            Vector2 target = new Vector2(2, 2);
Ghost ghost = gs.Ghostpack.Ghosts[1];

//act
ghost.ChangeState(GhostState.released);

            //assert
            Assert.IsTrue(ghost.CurrentState is Chase);*/