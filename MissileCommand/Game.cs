using Aiv.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{

    static class Game
    {
        //public static Window window;
        public static Cloud cloud;
        public static Cannon cannon1;
        public static Cannon cannon2;
        public static Cannon cannon3;
        public static Crosshair crosshair;
        public static Window window;
        private static Sprite background;
        private static Sprite GameOverScreen;
        private static Sprite Cloud;
        private static float time;
        public static float SpawnTime;
        private static float GameOverTime;
        public static bool isPresses1;
        public static bool isPresses2;
        public static bool isPresses3;

        
        static Game()
        {
            window = new Window(1280, 720, "Missile Command", PixelFormat.RGB);
            window.CursorVisible = false;
            Utils.window = window;

            cloud = new Cloud();
            cannon1 = new Cannon(50, 670);
            cannon2 = new Cannon(window.width * 0.5f, 670);
            cannon3 = new Cannon(window.width - 50, 670);
            crosshair = new Crosshair();
            background = new Sprite("Assets/Background.png");
            GameOverScreen = new Sprite("Assets/GameOver.png");
            Cloud = new Sprite("Assets/Cloud.png");
            SpawnTime = 5f;
            isPresses1 = false;
            isPresses2 = false;
            isPresses3 = false;
        }

        public static bool Opened()
        {
            return window.opened;
        }

        public static void Input()
        {
            crosshair.Input();
            //__________________________________________________
            if (window.GetKey(KeyCode.A) && isPresses1 == false)
            {
                isPresses1 = true;
                cannon1.Charge(crosshair);
            }
            if (!window.GetKey(KeyCode.A))
            {
                isPresses1 = false;
            }
            //__________________________________________________
            if (window.GetKey(KeyCode.S) && isPresses2 == false)
            {
                isPresses2 = true;
                cannon2.Charge(crosshair);
            }
            if (!window.GetKey(KeyCode.S))
            {
                isPresses2 = false;
            }
            //__________________________________________________
            if (window.GetKey(KeyCode.D) && isPresses3 == false)
            {
                isPresses3 = true;
                cannon3.Charge(crosshair);
            }
            if (!window.GetKey(KeyCode.D))
            {
                isPresses3 = false;
            }

            //______________________________
            if (window.GetKey(KeyCode.Esc))
                {
                    window.opened = false;
                }
            //______________________________
        }

        public static void Update()
        {
            if (SpawnTime > 0.1f)
            {
                SpawnTime -= 0.0008f;
            }
            
            time += window.deltaTime;
            MissileManager.Update();
            if (time > SpawnTime)
            {
                cloud.Update();
                time = 0;
            }
            EnemyMissileManger.Update();
            HouseManager.Update();
            Ship.Update();
        }

        public static void Draw()
        {
            Utils.ClearScreen();
            Utils.DrawSprite(background, 0, 0, 1, 0, 0, background.width, background.height);
            cannon1.draw();
            cannon2.draw();
            cannon3.draw();
            MissileManager.Draw();
            MissileManager.DrawExplosion();
            EnemyMissileManger.Draw();
            HouseManager.Draw();
            Ship.Draw();
            Utils.DrawSprite(Cloud, 0, 0, 1, 0, 0, Cloud.width, Cloud.height);
            crosshair.Draw();
            while (window.opened == false && GameOverTime < 5)
            {
                Utils.ClearScreen();
                Utils.DrawSprite(GameOverScreen, 0, 0, 1, 0, 0, GameOverScreen.width, GameOverScreen.height);
                GameOverTime += window.deltaTime;
                window.Blit();
            }
            window.Blit();
        }

    }
}
