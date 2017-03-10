using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class random
    {
        public void ParseTest()
        {
            
            GameState gs = new GameState();


            gs = GameState.Parse(@"H:\levels.txt");

 
            for (int i = 0; i < gs.Maze.Size; i++)
            {
                for (int j = 0; j < gs.Maze.Size; j++)
                {
                    Console.WriteLine(gs.Maze[i, j]);
                }
            }
        }
    }
}
