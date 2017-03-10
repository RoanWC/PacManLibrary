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
            GameState gs = new GameState();
            Pen pen = new Pen();    
            Maze maze = new Maze();
            GhostPack ghostPack = new GhostPack();

            gs.Pen = pen;
            gs.Maze = maze;
            gs.Ghostpack = ghostPack;
           
            ScoreAndLives score = new ScoreAndLives(gs);
            Pacman pacMan;// = new Pacman(gs,);

            gs.ScoreAndLives = score;
          //  gs.Pacman = pacMan;

            string[] read = File.ReadAllLines(filecontent);
            Tile[,] tile = new Tile[read.Length, read[0].Length];
           
            for (int i = 0; i < read.Length; i++)
            {  
                string[] seperate = read[i].Split(',');
                for (int j = 0; j < read.Length; j++) {
                    switch (seperate[j])
                    {
                        case "w":
                            Wall wall = new Wall(i, j);
                            tile[i, j] = wall;
                            break;
                        case "p":
                            Pellet pel = new Pellet();
                            Path pelletPath = new Path(i, j, pel);                    
                            // but IncrementScore is protected                
                            //pel.Collision += gs.ScoreAndLives.incrementScore(pelletPath);
                            tile[i, j] = pelletPath;                  
                            break;                  
                        case "m":
                            Path emptyPath = new Path(i, j);
                            tile[i, j] = emptyPath;
                            break;
                        case "x":
                            Path emptyPathPen = new Path(i, j);
                            tile[i, j] = emptyPathPen;
                            gs.Pen.AddTile(tile[i, j]);                      
                            break;
                        case "e":
                            Energizer energizer = new Energizer(gs.Ghostpack);
                            Path energPath = new Path(i, j, energizer);

                            //energizer.Collision += gs.ScoreAndLives.incrementScore(energPath);
                            tile[i, j] = energPath;
                            break;
                        case "1":
                            // Ghost1 is not inside of pen tho
                            //(gs.Pacman.PacManPosition.X + 2, gs.Pacman.PacManPosition.Y)
                            Vector2 targetGhost1 = new Vector2(1,1);
                            Ghost blinky = new Ghost(gs, i, j, targetGhost1, GhostState.chase, Color.Red);

                            //subscribe to collision and pacmandied event
                            gs.Ghostpack.Add(blinky);
                            Path emptyPathGhostBlinky = new Path(i, j);
                            tile[i, j] = emptyPathGhostBlinky;
                            break;                    
                        case "2":
                            Vector2 targetGhost2 = new Vector2(5, 5);
                            Ghost pinky = new Ghost(gs, i, j, targetGhost2, GhostState.penned, Color.HotPink);
                            //subscribe to collision and pacmandied event
                            gs.Ghostpack.Add(pinky);
                            Path emptyPathGhostPinky = new Path(i, j);
                            tile[i, j] = emptyPathGhostPinky;
                            gs.Pen.AddTile(tile[i, j]);
                            gs.Pen.AddToPen(pinky);
                            break;
                        case "3":
                            Vector2 targetGhost3 = new Vector2(2,2);
                            Ghost inky = new Ghost(gs, i, j, targetGhost3, GhostState.penned, Color.Cyan);
                            //subscribe to collision and pacmandied event
                            gs.Ghostpack.Add(inky);
                            Path emptyPathGhostInky = new Path(i, j);
                            tile[i, j] = emptyPathGhostInky;
                            gs.Pen.AddTile(tile[i, j]);
                            gs.Pen.AddToPen(inky);
                            break;
                        case "4":
                            Vector2 targetGhost4 = new Vector2(4, 4);
                            Ghost clyde = new Ghost(gs, i, j, targetGhost4, GhostState.penned, Color.LightGreen);
                            //subscribe to collision and pacmandied event
                            gs.Ghostpack.Add(clyde);
                            Path emptyPathGhostClyde = new Path(i, j);
                            tile[i, j] = emptyPathGhostClyde;
                            gs.Pen.AddTile(tile[i, j]);
                            gs.Pen.AddToPen(clyde);
                            break;
                        case "P":
                            Path emptyPathPacMan= new Path(i, j);
                            tile[i, j] = emptyPathPacMan;
                            gs.Pacman = new Pacman(gs, i, j);                         
                            break;              
                    }                
                }    
            }
            gs.Maze.SetTiles(tile);
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
