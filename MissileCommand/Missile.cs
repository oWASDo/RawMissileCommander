using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class Missile
    {
        public enum MissileStatus { UNEXPLODED, FLYING, EXPLODING}
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 FinalPosition { get; set; }
        public Vector2 LastPosition { get; set; }
        public bool isActive;
        public float MaxMagnitude;
        public Sprite sprite;
        public MissileStatus status;
        public int ExplosionSize;
        private float speed;
        public int explosionLimit { get; }
        private float time;
        private float switchTime;

        public Missile(string spriteM, float speedM)
        {
            isActive = false;
            sprite = new Sprite(spriteM);
            Position = new Vector2(0 - explosionLimit, 0 - explosionLimit);
            Direction = new Vector2(0,0);
            FinalPosition = new Vector2(0, 0);
            speed = speedM;
            explosionLimit = 50;
            switchTime = 0.5f;
        }


        public void Update()
        {
            //Aggiorna la posizione del missile e il tempo di colorazione
            //Update missile's position and time of coloration
            float space = speed * Game.window.deltaTime;
            Position.x += Direction.x * space;
            Position.y += Direction.y * space;
            
            time += Game.window.deltaTime;
            if (time >= switchTime + switchTime)
                time = 0;
        }

        //Metodo per disegnare il missile
        //Draw of the misslile
        public void Draw()
        {
            if (isActive == true)
            {
                Utils.DrawSprite(sprite, (int)Position.x - sprite.width / 2, (int)Position.y - sprite.height / 2, 1, 0, 0, sprite.width / 2, sprite.height);
                if (time >= switchTime)
                {
                    Utils.DrawSprite(sprite, (int)Position.x - sprite.width / 2, (int)Position.y - sprite.height / 2, 1, sprite.width / 2, 0, sprite.width / 2, sprite.height);
                }
            }
            
        }

        //Metodo per disegnare l'esplosione
        //Drawing of explosion
        public void DrawExplosion()
        {
            if (ExplosionSize < explosionLimit - 1)
            {
                Utils.DrawSolidCircle(Game.window, Position.x, Position.y, ExplosionSize, 255, 128, 0, 255);
            }
        }
    }
}
