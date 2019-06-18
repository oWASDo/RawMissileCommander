using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace MissileCommand
{
    class Utils
    {
        public static Window window;

        public static void PutPixel(float x, float y, byte r, byte g, byte b)
        {
            if (x < 0 || x > window.width - 1)
            {
                return;
            }
            if (y < 0 || y > window.height - 1)
            {
                return;
            }
            int position = (int)((y * window.width * 3) + (x * 3));
            window.bitmap[position] = r;
            window.bitmap[position + 1] = g;
            window.bitmap[position + 2] = b;
        }

        public static void PutPixelDouble(double x, double y, byte r, byte g, byte b, byte a)
        {
            if (x < 0 || x > window.width - 1)
            {
                return;
            }
            if (y < 0 || y > window.height - 1)
            {
                return;
            }
            int position = ((int)y * window.width * 3) + ((int)x * 3);

            float alpha = a / 255f;
            byte backR = window.bitmap[position];
            byte backG = window.bitmap[position + 1];
            byte backB = window.bitmap[position + 2];


            window.bitmap[position] = (byte)(r * alpha + backR * (1 - alpha));
            window.bitmap[position + 1] = (byte)(g * alpha + backG * (1 - alpha));
            window.bitmap[position + 2] = (byte)(b * alpha + backB * (1 - alpha));

        }

        public static void DrawHorizontalLine(Window window, float x, float y, int width, byte r, byte g, byte b, byte a)
        {
            for (int i = (int)x; i < x + width; i++)
            {
                PutPixelDouble( i, y, r, g, b, a);
            }
        }

        public static void DrawVerticalLine(Window window, float x, float y, int height, byte r, byte g, byte b, byte a)
        {
            for (int i = (int)y; i < y + height; i++)
            {
                PutPixelDouble( x, i, r, g, b, a);
            }
        }

        public static void DrawRectangle(Window window, float x, float y, int width, int height, byte r, byte g, byte b, byte a)
        {
            DrawHorizontalLine(window, x, y, height, r, g, b, a);
            DrawHorizontalLine(window, x, y + height, height, r, g, b, a);
            DrawVerticalLine(window, x, y, height, r, g, b, a);
            DrawVerticalLine(window, x + width, y, height, r, g, b, a);

        }

        public static void DrawSolidRectangle(Window window, float x, float y, int width, int height, byte r, byte g, byte b, byte a)
        {
            for (int i = (int)y; i < y + height; i++)
            {
                DrawHorizontalLine(window, x, i, width, r, g, b, a);
            }
        }

        public static void DrawCircle(Window window, float x, float y, int radius, byte r, byte g, byte b, byte a)
        {


            for (double i = 0; i < 360; i++)
            {

                int  startX = (int)(Math.Cos((i * Math.PI) / 180) * radius) + (int)x;
                int  startY = (int)y - (int)(Math.Sin((i * Math.PI) / 180) * radius);
                PutPixel( startX, startY, r, g, b);
            }

        }

        public static void DrawSolidCircle(Window window, float x, float y, int radius, byte r, byte g, byte b, byte a)
        {

            for (int i = radius; i > 0; i--)
            {
                DrawCircle(window, x, y, i, r, g, b, a);
            }

        }

        public static void DrawSprite(Sprite sprite, int x, int y, float alpha, int xOffset, int yOffset, int width, int height)
        {
            if (xOffset < 0 || xOffset > sprite.width - 1)
            {
                return;
            }
            if (yOffset < 0 || yOffset > sprite.height - 1)
            {
                return;
            }
            if (xOffset + width > sprite.width)
            {
                return;
            }
            if (yOffset + height > sprite.height)
            {
                return;
            }

            for (int i = yOffset; i < yOffset + height; i++)
            {
                for (int j = xOffset; j < xOffset + width; j++)
                {
                    int index = (i * sprite.width * 4) + (j * 4);
                    byte spriteR = sprite.bitmap[index];
                    byte spriteG = sprite.bitmap[index + 1];
                    byte spriteB = sprite.bitmap[index + 2];
                    byte spriteA = (byte)(sprite.bitmap[index + 3] * alpha);
                    PutPixelDouble(x + j - xOffset, y + i - yOffset, spriteR, spriteG, spriteB, spriteA);
                }
            }
        }

        public static void ClearScreen()
        {
            for (int i = 0; i < window.bitmap.Length; i++)
            {
                window.bitmap[i] = 0;
            }
        }

        public static bool CollisionCircleToCircle(Vector2 circleVectorCenter1, Vector2 circleVectorCenter2, int ray1, int ray2)
        {
            Vector2 vector = Vector2.VectorSubtraction(circleVectorCenter1, circleVectorCenter2);
            if (vector.magnitude() < (double)ray1 - (double)ray2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CollisionRectangleToCircle(Vector2 rectPos, Vector2 circleCenter, int width, int height, int radius)
        {
            Vector2 point1 = new Vector2(rectPos.GetX(), rectPos.GetY());
            Vector2 point2 = new Vector2(rectPos.GetX() + width, rectPos.GetY());
            Vector2 point3 = new Vector2(rectPos.GetX(), rectPos.GetY() + height);
            Vector2 point4 = new Vector2(rectPos.GetX() + width, rectPos.GetY() + height);
            Vector2 vector1 = new Vector2(point1.x - circleCenter.x, point1.y - circleCenter.y);//Vector2.VectorSubtraction(point1, circleCenter);
            Vector2 vector2 = new Vector2(point2.x - circleCenter.x, point2.y - circleCenter.y);//Vector2.VectorSubtraction(point2, circleCenter);
            Vector2 vector3 = new Vector2(point3.x - circleCenter.x, point3.y - circleCenter.y);//Vector2.VectorSubtraction(point4, circleCenter);
            Vector2 vector4 = new Vector2(point4.x - circleCenter.x, point4.y - circleCenter.y);//Vector2.VectorSubtraction(point4, circleCenter);

            if (vector1.magnitude() < radius || vector2.magnitude() < radius || vector3.magnitude() < radius || vector4.magnitude() < radius)
            {
                return true;
            }
            return false;
            
        }

        public static bool CollisionRectangelToRectangle(Vector2 rect1, Vector2 rect2, int widthRect1, int heightRect1, int widthRect2, int heightRect2)
        {
            Vector2 point1_1 = new Vector2(rect1.GetX(), rect1.GetY());
            Vector2 point2_1 = new Vector2(rect1.GetX() + widthRect1, rect1.GetY());
            Vector2 point3_1 = new Vector2(rect1.GetX(), rect1.GetY() + heightRect1);
            Vector2 point4_1 = new Vector2(rect1.GetX() + widthRect1, rect1.GetY() + heightRect1);

            Vector2 point1_2 = new Vector2(rect2.GetX(), rect2.GetY());
            Vector2 point2_2 = new Vector2(rect2.GetX() + widthRect1, rect2.GetY());
            Vector2 point3_2 = new Vector2(rect2.GetX(), rect2.GetY() + heightRect1);
            Vector2 point4_2 = new Vector2(rect2.GetX() + widthRect1, rect2.GetY() + heightRect1);
            if (point1_1.GetX() >= point1_2.GetX() && point1_1.GetX() <= point2_2.GetX() && point1_1.GetY() >= point1_2.GetY() && point1_1.GetY() <= point3_2.GetY() ||
                point2_1.GetX() >= point1_2.GetX() && point2_1.GetX() <= point2_2.GetX() && point2_1.GetY() >= point1_2.GetY() && point2_1.GetY() <= point3_2.GetY() ||
                point3_1.GetX() >= point1_2.GetX() && point3_1.GetX() <= point2_2.GetX() && point3_1.GetY() >= point1_2.GetY() && point3_1.GetY() <= point3_2.GetY() ||
                point4_1.GetX() >= point1_2.GetX() && point4_1.GetX() <= point2_2.GetX() && point4_1.GetY() >= point1_2.GetY() && point4_1.GetY() <= point3_2.GetY() ||
                point1_2.GetX() >= point1_1.GetX() && point1_2.GetX() <= point2_1.GetX() && point1_2.GetY() >= point1_1.GetY() && point1_2.GetY() <= point3_1.GetY() ||
                point2_2.GetX() >= point1_1.GetX() && point2_2.GetX() <= point2_1.GetX() && point2_2.GetY() >= point1_1.GetY() && point2_2.GetY() <= point3_1.GetY() ||
                point3_2.GetX() >= point1_1.GetX() && point3_2.GetX() <= point2_1.GetX() && point3_2.GetY() >= point1_1.GetY() && point3_2.GetY() <= point3_1.GetY() ||
                point4_2.GetX() >= point1_1.GetX() && point4_2.GetX() <= point2_1.GetX() && point4_2.GetY() >= point1_1.GetY() && point4_2.GetY() <= point3_1.GetY())
            {
                return true;
            }
            else
                return false;
        }
    }
}
