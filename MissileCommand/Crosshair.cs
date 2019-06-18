using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MissileCommand
{
    class Crosshair
    { 

        public Vector2 position;
        public int Width;
        public int Height;
        public Sprite cross;

        public Crosshair()
        {
            cross = new Sprite("Assets/Crosshair.png");
            position = new Vector2(Game.window.width * 0.5f, Game.window.height * 0.5f);
            Width = cross.width;
            Height = cross.height;
        }

        //Questo metodo sposta la posizione del mirino rispetto alla posizione del mouse
        //This method move the position of crosshair compared to mouse's position
        public void Input()
        {
            position.x = Game.window.mouseX;
            position.y = Game.window.mouseY;
        }

        //Metodo per disegnare il mirino
        //Method that draw the crosshair
        public void Draw()
        {
            Utils.DrawSprite(cross, (int)(position.x - Width * 0.5), (int)(position.y - Height * 0.5), 1, 0, 0, Width, Height);
        }


    }
}
