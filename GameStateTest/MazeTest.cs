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
            gs = GameState.Parse(@"H:\levels.csv");
            //HAVE TO CHANGE THE PATH 

            //act
            Maze maze = gs.Maze;

            //assert
            Assert.AreEqual(maze.Size, 23);
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
            gs = GameState.Parse(@"H:\C# Jaya\C# Pacman\levels.txt");
            Pellet pellet = new Pellet();

            //arrange
            Maze maze = gs.Maze;

            //assert
            Assert.AreEqual(maze[1, 1].Member().GetType(),pellet);
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
            gs = GameState.Parse(@"H:\levels.txt");
            //3 , 3 direction Up
            
            //act
            Maze maze = gs.Maze;
            List<Tile> list1 = maze.GetAvailableNeighbours(new Vector2(3, 3), Direction.Right);//should only be 1 available neighbours
            List<Tile> list2 = maze.GetAvailableNeighbours(new Vector2(3, 3), Direction.Up);//should only be 2 available neighbours

            //assert
            Assert.AreEqual(1, list1.Count);
            Assert.AreEqual(2, list2.Count);
        }

        [TestMethod]
        public void TestCheckMembersLeft()
        {
            //arrange
            GameState game1Pellet = new GameState();
            game1Pellet = GameState.Parse(@"H:\levelsPen0Pellet.txt");

            GameState gameAllWalls = new GameState();
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
