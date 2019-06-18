using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class Vector2
    {
        public float x;
        public float y;

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public Vector2()
        {
                
        }
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public void SetX(float X)
        {
            x = X;
        }
        public void SetY(float Y)
        {
            y = Y;
        }
        public static Vector2 VectorAdd(Vector2 vec, Vector2 vec2)
        {
            Vector2 vec3 = new Vector2(vec.x + vec2.x, vec.y + vec2.y);
            return vec3;

        }
        public static Vector2 VectorSubtraction(Vector2 vec2, Vector2 vec1)
        {
            Vector2 vec3 = new Vector2(vec2.x - vec1.x, vec2.y - vec2.y);
            return vec3;
        }
        public static Vector2 VectorScale(Vector2 vec, float amount)
        {
            vec.x *= amount;
            vec.y *= amount;
            return vec;
        }
        public Vector2 Normalize()
        {
            float ipot = magnitude();
            x = x / ipot;
            y = y / ipot;
            return new Vector2(x, y);
        }
        public float magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
    }
}
