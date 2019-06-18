using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    static class HouseManager
    {
        public static House[] Houses;
        private static float offset;

        static HouseManager()
        {
            offset = 30;
            Houses = new House[6];
            //for (int i = 0; i < Houses.Length; i++)
            //{
                Houses[0] = new House(146, Game.window.height - offset);
                Houses[1] = new House(346, Game.window.height - offset);
                Houses[2] = new House(546, Game.window.height - offset);
                Houses[3] = new House(Game.window.width / 2 + 146 - 50, Game.window.height - offset);
                Houses[4] = new House(Game.window.width / 2 + 346 - 50, Game.window.height - offset); 
                Houses[5] = new House(Game.window.width / 2 + 546 - 50, Game.window.height - offset);
            //}
        }

        //Aggiorna le case
        //Update the house
        public static void Update()
        {
            //Se tutte le case non hanno energia il gioco si chiude
            if (Houses[0].Nrg == 0 && Houses[1].Nrg == 0 && Houses[2].Nrg == 0 && Houses[3].Nrg == 0 && Houses[4].Nrg == 0 && Houses[5].Nrg == 0)
            {
                Game.window.opened = false;
            }

            foreach (House house in Houses)
            {
                if (house.Nrg > 0)
                {
                    foreach (Missile enemyMissile in EnemyMissileManger.EnemyMissiles)
                    {
                        //Se i missili nemico collidono con le case, questi si disattivano e le case perdono energia
                        //If the enemy missiles collide with houses, these are switched off and the houses lose energy
                        if (enemyMissile.isActive == true && Utils.CollisionRectangelToRectangle(house.Position, enemyMissile.Position,house.width, house.height, enemyMissile.sprite.width /2, enemyMissile.sprite.height))
                        {
                            enemyMissile.isActive = false;
                            house.Nrg -= 1;
                        }
                    }
                }
                house.Update();
            }
        }

        //Disegno ogni casa
        //Draw all the house
        public static void Draw()
        {
            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].Draw();
            }
        }
    }
}
