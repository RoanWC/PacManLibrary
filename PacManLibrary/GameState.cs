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
            gs.Pen = new Pen();
            gs.Maze = new Maze();
            gs.Ghostpack = new GhostPack();
            gs.ScoreAndLives = new ScoreAndLives(gs);
            gs.Pacman = new Pacman(gs);

            string[] read = File.ReadAllLines(filecontent);
            Tile[,] tile = new Tile[read.Length, read.Length];
           
            for (int i = 0; i < read.Length; i++)
            {  
                string[] seperate = read[i].Split(',');
                for (int j = 0; j < read.Length; j++) {
                    switch (seperate[i])
                    {
                        case "w":
                            Wall wall = new Wall(j, i);
                            tile[j, i] = wall;
                            break;
                        case "p":
                            Pellet pel = new Pellet();
                            Path pelletPath = new Path(j, i, pel);    
                            // subscribing to that event                              
                            pel.Collision += gs.ScoreAndLives.incrementScore;
                            tile[j, i] = pelletPath;                  
                            break;                  
                        case "m":
                            Path emptyPath = new Path(j, i);
                            tile[j, i] = emptyPath;
                            break;
                        case "x":
                            Path emptyPathPen = new Path(j, i);
                            tile[j, i] = emptyPathPen;
                            gs.Pen.AddTile(tile[j, i]);                      
                            break;
                        case "e":
                            Energizer energizer = new Energizer(gs.Ghostpack);
                            Path energPath = new Path(j, i, energizer);
                            energizer.Collision += gs.ScoreAndLives.incrementScore;
                            tile[j, i] = energPath;
                            break;
                        case "1":                       
                            Vector2 targetGhost1 = new Vector2(1,1);
                            Ghost blinky = new Ghost(gs, j, i, targetGhost1, GhostState.chase, Color.Red);

                            blinky.Collision += gs.ScoreAndLives.incrementScore;
                            blinky.PacManDies += gs.ScoreAndLives.deadPacman;               
                            gs.Ghostpack.Add(blinky);
                            Path emptyPathGhostBlinky = new Path(j, i);
                            tile[j, i] = emptyPathGhostBlinky;
                            break;                    
                        case "2":
                            Vector2 targetGhost2 = new Vector2(5, 5);
                            Ghost pinky = new Ghost(gs, j, i, targetGhost2, GhostState.penned, Color.HotPink);
                            //subscribe to collision and pacmandied event
                            pinky.Collision += gs.ScoreAndLives.incrementScore;
                            pinky.PacManDies += gs.ScoreAndLives.deadPacman;
                            // add ghost to ghostpack
                            gs.Ghostpack.Add(pinky);
                            Path emptyPathGhostPinky = new Path(j, i);
                            tile[j, i] = emptyPathGhostPinky;
                            // adding empty tile to the pen
                            gs.Pen.AddTile(tile[j, i]);
                            gs.Pen.AddToPen(pinky);
                            break;
                        case "3":
                            Vector2 targetGhost3 = new Vector2(2 ,2);
                            Ghost inky = new Ghost(gs, j, i, targetGhost3, GhostState.penned, Color.Cyan);
                            //subscribe to collision and pacmandied event
                            inky.Collision += gs.ScoreAndLives.incrementScore;
                            inky.PacManDies += gs.ScoreAndLives.deadPacman;
                            gs.Ghostpack.Add(inky);
                            Path emptyPathGhostInky = new Path(j, i);
                            tile[j, i] = emptyPathGhostInky;
                            gs.Pen.AddTile(tile[j, i]);
                            gs.Pen.AddToPen(inky);
                            break;
                        case "4":
                            Vector2 targetGhost4 = new Vector2(4, 4);
                            Ghost clyde = new Ghost(gs, j, i, targetGhost4, GhostState.penned, Color.LightGreen);
                            //subscribe to collision and pacmandied event
                            clyde.Collision += gs.ScoreAndLives.incrementScore;
                            clyde.PacManDies += gs.ScoreAndLives.deadPacman;
                            gs.Ghostpack.Add(clyde);
                            Path emptyPathGhostClyde = new Path(j, i);
                            tile[j, i] = emptyPathGhostClyde;
                            gs.Pen.AddTile(tile[j, i]);
                            gs.Pen.AddToPen(clyde);
                            break;
                        case "P":
                            Path emptyPathPacMan= new Path(j, i);
                            tile[j, i] = emptyPathPacMan;
                            gs.Pacman = new Pacman(gs);
                            gs.Pacman.PacManPosition = new Vector2(j, i);                       
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
