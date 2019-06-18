using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Game.Opened())
            {
                //UPDATE
                Game.Update();
                
                //UPDATE
                Game.Input();

                //DRAW
                Game.Draw();
                
            }
        }
    }
}
