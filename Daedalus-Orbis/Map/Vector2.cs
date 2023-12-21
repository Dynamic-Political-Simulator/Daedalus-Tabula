using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daedalus_Orbis.Map
{
    public class Vector2
    {
        public double X;
        public double Y;

        [JsonConstructor]
        public Vector2() { }
        
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 Add(Vector2 p1, Vector2 p2)
        {
            return new Vector2(p1.X+p2.X, p1.Y+p2.Y);
        }

        public static Vector2 Subtract(Vector2 p1, Vector2 p2)
        {
            return new Vector2(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Vector2 Scale(Vector2 p1, Vector2 a)
        {
            return new Vector2(p1.X * a.X, p1.Y * a.Y);
        }

        public static Vector2 Scale(Vector2 p1, double a)
        {
            return new Vector2(p1.X * a, p1.Y * a);
        }
    }
}
