using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace GameStateTest
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void TestPostion()
        {
            //arrange
            Wall wall1 = new Wall(1, 1);
            Wall wall2 = new Wall(1, 1);

            //act
            //assert
        }

        [TestMethod]
        public void TestGetDistance()
        {
            //arrange
            Wall wall1 = new Wall(1, 1);
            Wall wall2 = new Wall(1, 1);
            Wall wall3 = new Wall(2, 2);

            //act
            float distance = wall1.GetDistance(wall2.Position);
            float diffDistance = wall1.GetDistance(wall3.Position);

            //assert
            Assert.AreEqual(0.0, distance);
            Assert.AreNotEqual(distance, diffDistance);

        }


    }
}
