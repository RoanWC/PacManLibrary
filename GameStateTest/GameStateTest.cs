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



            //assert

        }
    }
}
