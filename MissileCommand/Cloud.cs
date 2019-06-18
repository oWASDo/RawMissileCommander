using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class Cloud
    {

        public float StartY;
        public float FinalY;
        public float StartX;
        public float FinalX;
        
        public Cloud ()
        {
            StartY = 0;
            FinalY = Game.window.height;
        }

        //Metodo che ritorna un numero randomico
        //Method that return a random number
        public float GetRandom()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(0, Game.window.width);
        }

        //Questo metodo prende un missile libero, lo attiva e gli da una traiettoria
        //This method graba a free missile , actived and give a path to it
        public bool Update()
        {
            Missile m = EnemyMissileManger.GetEnemyFreeMissiles();
            if (m != null)
            {
                m.Position.x = GetRandom();
                m.Position.y = StartY;
                m.FinalPosition.x = GetRandom();
                m.FinalPosition.y = FinalY;
                m.Direction = new Vector2(m.FinalPosition.x - m.Position.x, m.FinalPosition.y - m.Position.y);
                m.Direction.Normalize();
                m.isActive = true;
                return true;
            }
            return false;
        }
    }
}
