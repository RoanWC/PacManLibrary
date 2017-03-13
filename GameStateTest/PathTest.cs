using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace GameStateTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void TestPathPostion()
        {
            //arrange
            Path path = new Path(1, 1);

            //act

            //arrange
            Assert.AreEqual(path.Position, new Path(1, 1).Position);
        }

        [TestMethod]
        public void TestCanEnter()
        {
            //arrange
            Path path = new Path(1,1);

            //act
            //assert
            Assert.IsTrue(path.CanEnter());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            //arrange
            Path path = new Path(1, 1);
            //act
            //assert
            Assert.IsTrue(path.IsEmpty());
        }
    }
}
