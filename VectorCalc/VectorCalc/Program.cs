using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorCalc
{
    class Vector
    {
        public double M,X,Y; // Magnitude
        public Vector(double m, double x, double y) //Create a method *Vector* with 3 variable
        {
            M = m;
            X = x;
            Y = y;
        }
        public Vector Sum(Vector vector) // Sum operation
        {
            return new Vector(M + vector.M, X + vector.X, Y + vector.Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(10, 6, 8); //Magnitude and phases of vector1
            Vector vector2 = new Vector(5, 4, 3); //Magnitude and phases of vector2

            Vector summ = vector1.Sum(vector2); // geting the 3rd vector and using sum opertion
            Console.WriteLine("Vector1 is: " + vector1.M + " " + vector1.X + " " + vector1.Y);  // prints the Vector1
            Console.WriteLine("Vector2 is: " + vector2.M + " " + vector2.X + " " + vector2.Y);  // prints the Vector2
            Console.WriteLine("Your sum is: " + summ.M + " " + summ.X + " " + summ.Y);  // prints the summ 
            Console.ReadKey();
        }
    }
}