using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    static class MissileManager
    {

        public static Missile[] Missiles;

        static MissileManager()
        {
            //Creo un arrey di missili vuoti
            //Create an empty missiles arrey
            Missiles = new Missile[60];

            for (int i = 0; i < Missiles.Length; i++)
            {
                //Assegno ad ogni missile un immagine e una velocità
                //Allocate to every missile an immage and speed
                Missiles[i] = new Missile("Assets/missile.png",300);
            }

        }
        //Metodo che restituisce il primo missile libero all'interno dell'array(Missile == false)
        //Method that return first free missile inside the array(Missile == false)
        public static Missile GetFreeMissile()
        {
            for (int i = 0; i < Missiles.Length; i++)
            {
                if (Missiles[i].isActive == false)
                {
                    //Setto il missile come non esploso(missile = Missile.MissileStatus.UNEXPLODED)
                    //Set missile as unexploded(missile = Missile.MissileStatus.UNEXPLODED)
                    Missiles[i].status = Missile.MissileStatus.UNEXPLODED;
                    return Missiles[i];
                }
            }
            //Se nessun missile è disponibile il metodo non restituisco nulla
            //If any missile is available the method don't return nothing
            return null;
        }

        //Metodo per aggiornare ogni missile
        //Method for update every missile
        public static void Update()
        {
            //Update per ogni missile
            //Update for each missile
            foreach (Missile missile in Missiles)
            {
                if (//Se esce dallo schermo...
                    //If it get out from the screen...
                    missile.Position.x > Game.window.width || missile.Position.x < 0 ||
                    missile.Position.y > Game.window.height || missile.Position.y < 0 ||
                    //...o arriva alla sua posizione finale
                    //...or arriva to his final position
                    (missile.Position.x > missile.FinalPosition.x - 15 && missile.Position.x < missile.FinalPosition.x + 15 &&
                    missile.Position.y > missile.FinalPosition.y - 15 && missile.Position.y < missile.FinalPosition.y + 15))
                {
                    //Setto il nostro missile come esploso (missile = Missile.MissileStatus.EXPLODING)
                    //Set our missile as exploding (Missile.MissileStatus.EXPLODING)
                    missile.status = Missile.MissileStatus.EXPLODING;
                }

                //Se il nostro missile diventa libero
                //If our missile become free
                if (missile.isActive == false)
                {
                    //Lo posiziono fuori dallo schermo
                    //Set his position out of the screen
                    missile.Position.x = 0 - missile.explosionLimit;
                    missile.Position.y = 0 - missile.explosionLimit;
                }
            }
            //Per ogni nostro missile
            //For each our missile
            foreach (Missile missile in Missiles)
            {
                foreach (Missile enemyMissile in EnemyMissileManger.EnemyMissiles)
                {
                    //Se il missile nemico e l'esplosione del nostro missile sua esplosione collidono
                    //Is enemyMissile and our missile's explosion collide
                    if (Utils.CollisionRectangleToCircle(enemyMissile.Position, missile.Position, enemyMissile.sprite.width, enemyMissile.sprite.height, missile.ExplosionSize))
                    {
                        //Setto il nostro missile e il missile nemico come liber
                        //Set our missile an enemy missile as free
                        enemyMissile.isActive = false;
                        missile.isActive = false;
                    }
        
                }

            }

            //Per ogni nosto missile
            //For each our missile
            for (int i = 0; i < Missiles.Length; i++)
            {
                //Se "isActive" e uguale a true e il suo stato è in volo
                //If "isActive" is equal to true and his status is flyin
                if (Missiles[i].isActive == true && Missiles[i].status == Missile.MissileStatus.FLYING)
                {
                    //Aggiornalo
                    //Update it
                    Missiles[i].Update();
                }
            }
        }
     
        public static void Draw()
        {
            //Per ogni nosto missile
            //For each our missile
            for (int i = 0; i < Missiles.Length; i++)
            {
                //Se "isActive" e uguale a true
                //If "isActive" is equal to true
                if (Missiles[i].isActive == true)
                {
                    //Disegnalo
                    //Draw it
                    Missiles[i].Draw();
                }
            }
        }

        public static void DrawExplosion()
        {
            //Per ogni nosto missile
            //For each our missile
            foreach (Missile missile in Missiles)
            {
                //Se il suo stato è in esplosion e se non è fuori dallo schermo
                //If his state is equal to exploding and dosn't out of the screen
                if (missile.status == Missile.MissileStatus.EXPLODING && missile.Position.x != 0 - missile.explosionLimit && missile.Position.y!= 0 - missile.explosionLimit)
                {
                    //Disegna l'esplosione rispetto al nostro missile
                    //Draw explosion vis a vis our missile
                    missile.DrawExplosion();
                    //Aumenta la larghezza dell'esplosione
                    //Incress the width of explosion
                    missile.ExplosionSize++;
                    //Se l'esplosione del nostro missile ha ragiunto il proprio limite
                    //If our missile's explosion arrive to aur limit 
                    if (missile.ExplosionSize >= missile.explosionLimit)
                    {
                        //Setta il nostro missile come non esploso...
                        //Set our missile as unexploded...
                        missile.status = Missile.MissileStatus.UNEXPLODED;
                        //..., libero...
                        //..., free...
                        missile.isActive = false;
                        //...e aumenta la grandezza dell' esplosione fuori dal limite
                        //...end set the width of explosion out of limit
                        missile.ExplosionSize = 50;
                    }
                }
            }
        }
    }
}
