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
                        case "e":
                            Energizer energizer = new Energizer(gs.Ghostpack);
                            Path energPath = new Path(i, j, energizer);
                            gs.Maze[i, j] = energPath;
                            break;
                        case "1":
                            Vector2 target = new Vector2(gs.Pacman.PacManPosition.X + 2, gs.Pacman.PacManPosition.Y);
                            gs.Ghostpack = new Ghost(gs, i, j, )
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
    
                            break;           
                    }
                   
                }    
            }
   
            return gs;
        }
        public Pacman Pacman
        {
            get { return pacman; }
            private set { pacman = value; }
        }
        public GhostPack Ghostpack
        {
            get { return ghostpack; }
            private set { ghostpack = value; }
        }
        public Maze Maze
        {
            get { return maze; }
            private set { maze = value; }
        }
        public Pen Pen
        {
            get { return pen; }
            private set { pen = value; }
        }
        public ScoreAndLives Score
        {
            get { return score; }
            private set { score = value; }
        }
    }
}
