using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    static class Ship
    {

        public static Sprite Sprite;
        public static Vector2 Position;
        public static float Speed;
        public static float Time;
        public static float SpawnTime;

        static Ship()
        {
            Sprite = new Sprite("Assets/Ship.png");
            Position = new Vector2(0 - Sprite.width, Game.window.height * 0.4f);
            Speed = 100;
            Time = 0;
            SpawnTime = 30;
        }

        public static void Update()
        {
            Time += Game.window.deltaTime;
            //Tempo di apparizione
            //Spawn time
            if (Time >= SpawnTime)
            {
                float space = Speed * Game.window.deltaTime;
                Position.x += space;
            }

            //Collisioni tra navicella e missili
            //Collision among ship and missile
            foreach (Missile missile in MissileManager.Missiles)
            {
                if (Time >= SpawnTime && Utils.CollisionRectangleToCircle(Position,missile.Position,Sprite.width,Sprite.height,missile.ExplosionSize) || Position.x >= Game.window.width + Sprite.width)
                {
                    Position.x = 0 - Sprite.width;
                    Time = 0;
                }   
            }
        }

        //Metodo che disegna la navicella
        //Ship drawing
        public static void Draw()
        {
            Utils.DrawSprite(Sprite, (int)Position.x, (int)Position.y, 1, 0, 0, Sprite.width, Sprite.height - 3);
        }
    }
}
