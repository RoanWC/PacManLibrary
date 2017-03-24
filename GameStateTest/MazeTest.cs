using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameStateTest
{
    [TestClass]
    public class MazeTest
    {
        /// <summary>
        /// This method will test if the setTiles method is functioning properly
        /// </summary>
        [TestMethod]
        public void TestSetTiles()
        {
            //arrange
            GameState gs = new GameState();
            gs = GameState.Parse("test.txt");
            

            //act
            Maze maze = gs.Maze;

            //assert
            Assert.AreEqual(maze.Size, 3);
        }

        /// <summary>
        /// This method will test the indexer to make sure it 
        /// points to the correct index.
        /// </summary>
        [TestMethod]
        public void TestIndexer()
        {
            //act
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            Pellet pellet = new Pellet();

            //arrange
           

            //assert
            Assert.AreEqual(gs.Maze[1, 1].Member().GetType(),pellet.GetType());
        }

        /// <summary>
        /// To test the GetAvailableNeighbours Method I made 2 lists
        /// that will hold the results of 2 calls of GetAvailableNeighbours 
        /// with different directions.The Right direction will only return 
        /// 1 tile in the list given the postion, and the Up direction will 
        /// return a list with 2 tiles in it.
        /// </summary>
        [TestMethod]
        public void TestGetAvailableNeighbours()
        {
            //arrange
            GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            //3 , 3 direction Up
            
            //act
            
            List<Tile> list1 = gs.Maze.GetAvailableNeighbours(new Vector2(1, 1), Direction.Right);//should only be 2 available neighbours
            List<Tile> list2 = gs.Maze.GetAvailableNeighbours(new Vector2(1, 1), Direction.Up);//should only be 1 available neighbours

            //assert
            Assert.AreEqual(2, list1.Count);
            Assert.AreEqual(1, list2.Count);
        }

        [TestMethod]
        public void TestCheckMembersLeft()
        {
            //arrange
            GameState game1Pellet = new GameState();
            //This url is a very small csv file that is 2 by 2 that contains 1 pellet
            //had issues with getting it as a reference
            game1Pellet = GameState.Parse(@"H:\levelsPen0Pellet.txt");

            GameState gameAllWalls = new GameState();
            //This url is a very small csv file that is 2 by 2 that contains 0 collidable members
            //had issues with getting it as a reference
            gameAllWalls = GameState.Parse(@"H:\levelsPen0Pellet.txt");

            //act
            Maze maze1Pel = game1Pellet.Maze;
            Maze maze0Pel = gameAllWalls.Maze;
            var wasFired1 = false;
            var wasFired0 = false;

            maze0Pel.PacmanWon += delegate () { wasFired0 = true; };
            maze1Pel.PacmanWon += delegate () { wasFired1 = true; };

            //assert
            Assert.IsTrue(wasFired0);
            Assert.IsFalse(wasFired1);
        }
    }
}
