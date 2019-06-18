using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Codecs;

namespace MissileCommand
{
    class Cannon
    {
       
        public Vector2 position;
        public Sprite cannon;
        public int Width;
        public int Height;

        public Cannon(float x,float y)
        {
            cannon = new Sprite("Assets/Cannon.png");
            position = new Vector2(x, y);
            Width = cannon.width;
            Height = cannon.height;
        }

        //Questo metodo prende un missile libero, lo attiva e gli da una traiettoria
        //This method graba a free missile , actived and give a path to it 
        public bool Charge(Crosshair crosshair)
        {
            Missile m = MissileManager.GetFreeMissile();
            if (m != null)
            {
                m.Position.x = position.x;
                m.Position.y = position.y;
                m.FinalPosition.x = crosshair.position.x;
                m.FinalPosition.y = crosshair.position.y;
                m.Direction = new Vector2(m.FinalPosition.x - m.Position.x, m.FinalPosition.y - m.Position.y);
                m.MaxMagnitude = m.Direction.magnitude();
                m.Direction.Normalize();
                m.ExplosionSize = 0;
                m.isActive = true;
                m.status = Missile.MissileStatus.FLYING;
                return true;
            }
            return false;
        }

        //Metodo per disegnare un cannone
        //Method that draw a canon
        public void draw()
        {
            Utils.DrawSprite(cannon, (int)(position.x - Width * 0.5f), (int)(position.y - Height * 0.5f), 1, 0, 0, cannon.width, cannon.height);
        }
    }
}
