using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace GameStateTest
{
    [TestClass]
    public class WallTest
    {
        [TestMethod]
        public void TestWallPostion()
        {
            //arrange
            Wall wall = new Wall(1, 1);

            //act

            //arrange
            Assert.AreEqual(wall.Position, new Wall(1, 1).Position);
        }

        [TestMethod]
        public void TestCanEnter()
        {
            //arrange
            Wall wall = new Wall(1,1);
            //act
            //assert
            Assert.IsFalse(wall.CanEnter());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            //arrange
            Wall wall = new Wall(1, 1);

            //assert
            Assert.AreEqual(wall.IsEmpty(), true);
        }
    }
}
