using System;    // Required libraries
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SquareCalc
{
    class Square        // class that represents a Square
    {
        static void Main(string[] args)
        {
            int side;
            Console.WriteLine("Enter the side of a square");  
            side = int.Parse(Console.ReadLine());     //get height imput from user
            Console.WriteLine("Area : {0}\nPerimeter : {1}", side * side, 4 * side);
            // Calculate area and perimeter and print on the screen
        }
    }
}
