using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class House
    {

        public Sprite SpriteCasaNrg3;
        public Sprite SpriteCasaNrg2;
        public Sprite SpriteCasaNrg1;
        public Sprite SpriteCasaNrg0;
        public Vector2 Position;
        public int Nrg;
        public float Time;
        public int height;
        public int width;

        public House(float X, float HouseBaseY)
        {
            SpriteCasaNrg3 = new Sprite("Assets/CasaNrg3.png");
            SpriteCasaNrg2 = new Sprite("Assets/CasaNrg2.png");
            SpriteCasaNrg1 = new Sprite("Assets/CasaNrg1.png");
            SpriteCasaNrg0 = new Sprite("Assets/CasaNrg0.png");
            Nrg = 3;
            Time = 0;
            height = SpriteCasaNrg3.height;
            width = SpriteCasaNrg3.width;
            Position = new Vector2(X, HouseBaseY);
        }

        public void Update()
        {
            if (Nrg == 0)
            {
                Time += Game.window.deltaTime;
                if (Time >= 1)
                    Time = 0;
            }
        }

        //Metodo per disegnare una casa a seconda della sua energia
        //Method that draw an house depending to his energy
        public void Draw()
        {
            if (Nrg == 3)
            {
                Utils.DrawSprite(SpriteCasaNrg3, (int)Position.x - SpriteCasaNrg3.width / 2, (int)Position.y - SpriteCasaNrg0.height, 1, 0, 0, SpriteCasaNrg3.width, SpriteCasaNrg3.height);
            }
            if (Nrg == 2)
            {
                Utils.DrawSprite(SpriteCasaNrg2, (int)Position.x - SpriteCasaNrg3.width / 2, (int)Position.y - SpriteCasaNrg0.height, 1, 0, 0, SpriteCasaNrg2.width, SpriteCasaNrg2.height);
            }
            if (Nrg == 1)
            {
                Utils.DrawSprite(SpriteCasaNrg1, (int)Position.x - SpriteCasaNrg3.width / 2, (int)Position.y - SpriteCasaNrg0.height, 1, 0, 0, SpriteCasaNrg1.width, SpriteCasaNrg1.height);
            }
            if (Nrg == 0)
            {
                if (Time <= 0.5f)
                {
                    Utils.DrawSprite(SpriteCasaNrg0, (int)Position.x - SpriteCasaNrg0.width / 4, (int)Position.y - SpriteCasaNrg0.height, 1, 0, 0, SpriteCasaNrg0.width/2, SpriteCasaNrg0.height);
                }
                else
                {
                    Utils.DrawSprite(SpriteCasaNrg0, (int)Position.x - SpriteCasaNrg0.width / 4, (int)Position.y - SpriteCasaNrg0.height, 1, SpriteCasaNrg0.width/2, 0, SpriteCasaNrg0.width/2, SpriteCasaNrg0.height);
                }
            }
        }
    }
}
