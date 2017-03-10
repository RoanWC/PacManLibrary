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


        }
    }
}
