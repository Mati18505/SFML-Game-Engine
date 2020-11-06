using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathTrigonometry
{
    static class Matht
    {
        public static double Pythagoras(params double[] numbers)
        {
            double sum = 0;
            foreach (double item in numbers)
            {
                sum += Math.Pow(item, 2);
            }
            return Math.Sqrt(sum);
        }
        
        public static double ConvertAngleToPolar(double angle)
        {
            return (360 - (angle - 90)) % 360;
        }

        public static double ConvertRadianToAngle(double radian)
        {
            return radian * 180 / Math.PI;
        }

        public static double ConvertAngleToRadian(double angle)
        {
            return angle / 180 * Math.PI;
        }

        public static double VectorToRadian(Vector2 vector)
        {
            return Math.Atan2(vector.x, vector.y);
        }

        public static Vector2 RadianToVector(double radian)
        {
            return new Vector2((float)Math.Cos(radian), (float)Math.Sin(radian));
        }


        public static Vector2 NormalAngleToVector(double angle)
        {
            return RadianToVector(ConvertAngleToRadian(ConvertAngleToPolar(angle)));
        }
        
        public static double VectorToNormalAngle(Vector2 vector)
        {
            return ConvertRadianToAngle(VectorToRadian(vector));
        }
    }

    struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Round(int decimals)
        {
            x = (float)Math.Round(x, decimals);
            y = (float)Math.Round(y, decimals);
        }

        public double CalculateTheLength()
        {
            return Matht.Pythagoras(x, y);
        }

        
        public void Normalize()
        {
            float lenght = (float)CalculateTheLength();
            if (lenght == 0)
                return;
            x /= lenght;
            y /= lenght;
        }

        public static Vector2 up = new Vector2(0, 1);
        public static Vector2 down = new Vector2(0, -1);
        public static Vector2 right = new Vector2(1, 0);
        public static Vector2 left = new Vector2(-1, 0);
        
        public override string ToString()
        {
            return "[Vector2] X: " + x + " Y: " + y;
        }


        public static implicit operator Vector2f(Vector2 v)
        {
            return new Vector2f(v.x, v.y);
        }

        public static implicit operator Vector2(Vector2f v)
        {
            return new Vector2(v.X, v.Y);
        }


        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        } 
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        } 
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        } 
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        } 
        
        
        public static Vector2 operator +(Vector2 v1, Vector2f v2)
        {
            return new Vector2(v1.x + v2.X, v1.y + v2.Y);
        } 
        public static Vector2 operator -(Vector2 v1, Vector2f v2)
        {
            return new Vector2(v1.x - v2.X, v1.y - v2.Y);
        } 
        public static Vector2 operator *(Vector2 v1, Vector2f v2)
        {
            return new Vector2(v1.x * v2.X, v1.y * v2.Y);
        } 
        public static Vector2 operator /(Vector2 v1, Vector2f v2)
        {
            return new Vector2(v1.x / v2.X, v1.y / v2.Y);
        } 

        
        public static Vector2 operator +(Vector2 v, float f)
        {
            return new Vector2(v.x + f, v.y + f);
        }
        public static Vector2 operator -(Vector2 v, float f)
        {
            return new Vector2(v.x -f, v.y - f);
        }
        public static Vector2 operator *(Vector2 v, float f)
        {
            return new Vector2(v.x * f, v.y * f);
        }
        public static Vector2 operator /(Vector2 v, float f)
        {
            return new Vector2(v.x / f, v.y / f);
        }

        
        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }
    }
}
