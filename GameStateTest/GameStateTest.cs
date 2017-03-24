﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
//using System.IO;

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
        
            gs = GameState.Parse("test.txt");
         //   string[] read = File.ReadAllLines("test.txt");
         //   Console.WriteLine(read.GetLength(0));
            Tile[,] tile = new Tile[3, 3];
       
            //Wall w = new Wall(8, 0);
         /*
            Maze m1 = new Maze();
            // act
            tile[0, 0] = new Wall(0, 0);
            tile[0, 1] = new Wall(0, 1);
            tile[0, 2] = new Wall(0, 2);

          
            tile[1, 0] = new Wall(1, 0);
            Energizer energizer = new Energizer(gs.Ghostpack);
             Path energPath = new Path(1, 1, energizer);
            tile[1, 1] = energPath;
            tile[1, 2] = new Wall(1, 2);

            tile[2, 0] = new Wall(2, 0);          
            tile[2, 1] = new Wall(2, 1);
            tile[2, 2] = new Wall(2, 2);

            m1.SetTiles(tile);
            */
            Maze m = gs.Maze;
            Console.WriteLine(m[2, 2].Member());

            // assert
            Assert.IsTrue(m[0, 0] is Wall);
            Assert.IsTrue(m[1, 1] is Path);
            Assert.IsTrue(m[1, 1].Member() is Energizer);
            Assert.IsTrue(m[2, 2].Member() == null);
            //Assert.IsTrue(m[2, 3].IsEmpty());
            // Assert.AreSame(m1[0,0].GetType(), m[0,0].GetType());
            // Assert.AreSame(m1[1, 1].GetType(), m[1, 1].GetType());



        }
        
        [TestMethod]
        public void TestPellet(){
            //arrange 
            Pellet p = new Pellet();
            int points = p.Points;

            Assert.AreEqual(points, 10);
            
        }
        [TestMethod]
        public void TestEnergizer(){
            //arrange 
            GhostPack ghosts = new GhostPack();
            Energizer e = new Energizer(ghosts);
            int points = e.Points;

            Assert.AreEqual(points, 100);
        }
        /*
        [TestMethod]
        public void TestScoreAndLives(){
             GameState gs = new GameState();
            gs = GameState.Parse("levels.txt");
            ScoreAndLives sc = new ScoreAndLives(gs);
            Pellet p = new Pellet();           

            // make pacman die and check life
            gs.Pacman.PacManDies();
            // make pacman collide and check points
            sc.incrementScore(p);

            int lives = sc.Lives;
            int score = sc.Score;
            
            Assert.AreEqual(score, 10);

        }*/
    }
}
