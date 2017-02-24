using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PacManLibrary;
using System.IO;

namespace PacManLibrary
{
    public class GameState
    {
        // not sure
       /* private Pacman pacman;
        private GhostPack ghostpack;
        private Maze maze;
        private Pen pen;
        private ScoreAndLives score;*/
        public static GameState Parse(string filecontent)
        {         
            string[] read = File.ReadAllLines("levels.txt");
            GameState gs = new GameState();
            gs.ScoreAndLives = new ScoreAndLives(gs);
            //not sure
            gs.ScoreAndLives.Lives = 3;
            gs.ScoreAndLives.Score = 0;
            gs.Maze = new Maze();
            gs.Ghostpack = new GhostPack();
            string[,] grid = new string[23, 23];

            for (int i = 0; i < read.Length; i++)
            {
                string[] seperate = read[i].Split(' ');
                for (int j = 0; j < read.Length; j++) {
                    grid[i, j] = seperate[j];
                    switch (seperate[j])
                    {
                        case "w":
                            Wall wall = new Wall(i, j);
                            gs.Maze[i, j] = wall;
                            break;
                        case "p":
                            Pellet pel = new Pellet();
                            Path pelletPath = new Path(i, j, pel);
                            gs.Maze[i, j] = pelletPath;
                            break;                  
                        case "m":
                            Path emptyPath = new Path(i, j);
                            gs.Maze[i, j] = emptyPath;
                            break;
                        case "x":
                            Pen pen = new Pen();
                            gs.Maze[i, j] = pen;
                            break;
                        case "e":
                            Energizer energizer = new Energizer(gs.Ghostpack);
                            Path energPath = new Path(i, j, energizer);
                            gs.Maze[i, j] = energPath;
                            break;
                        case "1":
                            // Ghost1 is not inside of pen tho
                            Vector2 targetGhost1 = new Vector2(gs.Pacman.PacManPosition.X + 2, gs.Pacman.PacManPosition.Y);
                            gs.Ghostpack.Add(new Ghost(gs, i, j, targetGhost1, GhostState.penned, Color.HotPink));
                            break;                    
                        case "2":
                            Vector2 targetGhost2 = new Vector2(gs.Pacman.PacManPosition.X + 5, gs.Pacman.PacManPosition.Y);
                            gs.Ghostpack.Add(new Ghost(gs, i, j, targetGhost2, GhostState.penned, Color.Yellow));
                            break;
                        case "3":
                            Vector2 targetGhost3 = new Vector2(gs.Pacman.PacManPosition.X + 1, gs.Pacman.PacManPosition.Y);
                            gs.Ghostpack.Add(new Ghost(gs, i, j, targetGhost3, GhostState.penned, Color.Cyan));
                            break;
                        case "4":
                            Vector2 targetGhost4 = new Vector2(gs.Pacman.PacManPosition.X + 2, gs.Pacman.PacManPosition.Y);
                            gs.Ghostpack.Add(new Ghost(gs, i, j, targetGhost4, GhostState.penned, Color.LightGreen));
                            break;
                        case "P":
                            gs.Pacman = new Pacman(gs, i, j);                         
                            break;              
                    }
                   
                }    
            }
   
            return gs;
        }
        public Pacman Pacman
        {
            get { return Pacman; }
            private set { Pacman = value; }
        }
        public GhostPack Ghostpack
        {
            get { return Ghostpack; }
            private set { Ghostpack = value; }
        }
        public Maze Maze
        {
            get { return Maze; }
            private set { Maze = value; }
        }
        public Pen Pen
        {
            get { return Pen; }
            private set { Pen = value; }
        }
        public ScoreAndLives ScoreAndLives
        {
            get { return ScoreAndLives; }
            private set { ScoreAndLives = value; }
        }
    }
}
