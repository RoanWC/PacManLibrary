using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;

namespace PacManLibrary
{
    public class GameState
    {
        // not sure
        private Pacman pacman;
        private GhostPack ghostpack;
        private Maze maze;
        private Pen pen;
        private ScoreAndLives score;
        public static GameState Parse(string filecontent)
        {         
            string[] read = File.ReadAllLines("levels.txt");
            GameState gs = new GameState();
            int[,] grid = new int[23, 23];

            for (int i = 0; i < read.Length; i++)
            {
                //look at lab1 specs
                string[] seperate = read[i].Split('\t');
                for (int j = 0; j < read.Length; j++)
                    grid[i, j] = int.Parse(seperate[j]);
            }
    
             //go through grid to get position of every object
            return null;
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
