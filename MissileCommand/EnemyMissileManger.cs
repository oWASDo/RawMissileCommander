using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    static class EnemyMissileManger
    {
        public static Missile[] EnemyMissiles;


        static EnemyMissileManger()
        {
            //Creo un arrey di missili vuoti
            //Create an empty missiles arrey
            EnemyMissiles = new Missile[60];

            for (int i = 0; i < EnemyMissiles.Length; i++)
            {
                //Assegno ad ogni missile un immagine e una velocità
                //Allocate to every missile an immage and speed
                EnemyMissiles[i] = new Missile("Assets/EnemyMissile.png", 100);
            }
        }

        //Metodo che restituisce il primo missile libero all'interno dell'array(Missile == false)
        //Method that return first free missile inside the array(Missile == false)
        public static Missile GetEnemyFreeMissiles()
        {
            for (int i = 0; i < EnemyMissiles.Length; i++)
            {
                if (EnemyMissiles[i].isActive == false)
                {
                    return EnemyMissiles[i];
                }
                
            }
            return null;
        }

        //Metodo per aggiornare ogni missile
        //Method for update every missile
        public static void Update()
        {
            for (int i = 0; i < EnemyMissiles.Length; i++)
            {
                if (EnemyMissiles[i].isActive == true)
                {
                    EnemyMissiles[i].Update();
                }
                
            }

            foreach (Missile enemyMissile in EnemyMissiles)
            {
                //Se esce dallo schermo
                //If it get out from the screen
                if (enemyMissile.Position.x > Game.window.width || enemyMissile.Position.x < 0 ||
                    enemyMissile.Position.y > Game.window.height || enemyMissile.Position.y < 0)
                {
                    //Setto il nostro missile come falso
                    //Set our missile false
                    enemyMissile.isActive = false;
                }
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < EnemyMissiles.Length; i++)
            {
                if (EnemyMissiles[i].isActive == true)
                {
                    EnemyMissiles[i].Draw();
                }
                
            }
        }


    }
}
