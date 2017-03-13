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
    /// <summary>
    /// This class is responsible to set all the objects at their correct 
    ///  position depending on the letter in the file from which 
    ///it is reading through. We can access the state of the game through 
    /// the parse method.
    /// </summary>
    public class GameState
    {

        /// <summary>
        /// This method gets passed to it a filename. It will read the file 
        /// and set all the objects at their correct position depending 
        /// on the letter in the file. It returns a static GameState object 
        /// which allows us to access all the objects in the game.
        /// </summary>
        /// <param name="filecontent"></param>
        /// <returns>GameState of the whole pacman game</returns>
        public static GameState Parse(string filecontent)
        {
            // instantiating all objects 
            GameState gs = new GameState();
            Pen pen = new Pen();    
            Maze maze = new Maze();
            GhostPack ghostPack = new GhostPack();

            gs.Pen = pen;
            gs.Maze = maze;
            gs.Ghostpack = ghostPack;
           
            ScoreAndLives score = new ScoreAndLives(gs);
            Pacman pacMan = new Pacman(gs);

            gs.ScoreAndLives = score;
            gs.Pacman = pacMan;

            string[] read = File.ReadAllLines(filecontent);
            Tile[,] tile = new Tile[read.Length, read.Length];
           
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
                            // subscribing to that event                              
                            pel.Collision += gs.ScoreAndLives.incrementScore;
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
                            energizer.Collision += gs.ScoreAndLives.incrementScore;
                            tile[i, j] = energPath;
                            break;
                        case "1":                       
                            Vector2 targetGhost1 = new Vector2(1,1);
                            Ghost blinky = new Ghost(gs, i, j, targetGhost1, GhostState.chase, Color.Red);

                            blinky.Collision += gs.ScoreAndLives.incrementScore;
                            blinky.PacManDies += gs.ScoreAndLives.deadPacman;               
                            gs.Ghostpack.Add(blinky);
                            Path emptyPathGhostBlinky = new Path(i, j);
                            tile[i, j] = emptyPathGhostBlinky;
                            break;                    
                        case "2":
                            Vector2 targetGhost2 = new Vector2(5, 5);
                            Ghost pinky = new Ghost(gs, i, j, targetGhost2, GhostState.penned, Color.HotPink);
                            //subscribe to collision and pacmandied event
                            pinky.Collision += gs.ScoreAndLives.incrementScore;
                            pinky.PacManDies += gs.ScoreAndLives.deadPacman;
                            // add ghost to ghostpack
                            gs.Ghostpack.Add(pinky);
                            Path emptyPathGhostPinky = new Path(i, j);
                            tile[i, j] = emptyPathGhostPinky;
                            // adding empty tile to the pen
                            gs.Pen.AddTile(tile[i, j]);
                            gs.Pen.AddToPen(pinky);
                            break;
                        case "3":
                            Vector2 targetGhost3 = new Vector2(2 ,2);
                            Ghost inky = new Ghost(gs, i, j, targetGhost3, GhostState.penned, Color.Cyan);
                            //subscribe to collision and pacmandied event
                            inky.Collision += gs.ScoreAndLives.incrementScore;
                            inky.PacManDies += gs.ScoreAndLives.deadPacman;
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
                            clyde.Collision += gs.ScoreAndLives.incrementScore;
                            clyde.PacManDies += gs.ScoreAndLives.deadPacman;
                            gs.Ghostpack.Add(clyde);
                            Path emptyPathGhostClyde = new Path(i, j);
                            tile[i, j] = emptyPathGhostClyde;
                            gs.Pen.AddTile(tile[i, j]);
                            gs.Pen.AddToPen(clyde);
                            break;
                        case "P":
                            Path emptyPathPacMan= new Path(i, j);
                            tile[i, j] = emptyPathPacMan;
                            gs.Pacman = new Pacman(gs);
                            gs.Pacman.PacManPosition = new Vector2(i, j);                       
                            break;              
                    }                
                }    
            }
            gs.Maze.SetTiles(tile);
            return gs;
        }
        /// <summary>
        /// Property which returns the PacMan object and sets it 
        /// while reading through the file. 
        /// </summary>
        public Pacman Pacman
        {
            get;
            private set;
        }
        /// <summary>
        /// Property which returns the GhostPack object and sets it 
        /// while reading through the file. 
        /// </summary>
        public GhostPack Ghostpack
        {
            get;
            private set;
        }
        /// <summary>
        /// Property which returns the Maze object and sets its tile 
        /// by the end of the Parse method
        /// </summary>
        public Maze Maze
        {
            get;
            set;
        }
        /// <summary>
        /// Property which returns the Pen object and sets it 
        /// while reading through the file. 
        /// </summary>
        public Pen Pen
        {
            get;
            private set;
        }
        /// <summary>
        /// Property which returns the ScoreAndLives object and sets it 
        /// while reading through the file. 
        /// </summary>
        public ScoreAndLives ScoreAndLives
        {
            get;
            private set;
        }
    }
}
