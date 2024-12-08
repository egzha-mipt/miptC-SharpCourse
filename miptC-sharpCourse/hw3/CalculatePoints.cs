using System;
using DecimalMath; //https://www.nuget.org/packages/DecimalMath.DecimalEx#supportedframeworks-body-tab

namespace hw3 
{
    internal class CalculatePoint
    {
        public struct Point
        {
            public readonly decimal X; // public decimal x;
            public readonly decimal Y;
            public readonly decimal Z;
            public Point(decimal x, decimal y, decimal z)
            {
                X = x; //или лучше через this.x = x ?
                Y = y;
                Z = z;
            }
        }

        internal class Informer
        {
            protected void PrintToConsole(string data)
            {
                if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
                {
                    Console.WriteLine("Empty string");
                } else {
                    Console.WriteLine(data);    
                }
            }
        }
        
        public class Calculator : Informer
        {
            public new void PrintToConsole(string data)
            {
                base.PrintToConsole(data);
            }
            public decimal CalculateDistance(Point p1, Point p2)
            {
                decimal number = (p1.X - p2.X) * (p1.X - p2.X) + 
                                 (p1.Y - p2.Y) * (p1.Y - p2.Y) + 
                                 (p1.Z - p2.Z) * (p1.Z - p2.Z);
                decimal result = DecimalEx.Sqrt(number);
                // Console.WriteLine(result);
                return result;
            }
            public void PrintToConsole(Point p1, Point p2)
            {
                decimal distance = CalculateDistance(p1, p2);
                Console.WriteLine($"Distance between points: {distance}");
            }
            
            public void PrintToConsole(Point point)
            {
                Console.WriteLine($"x: {point.X}, y: {point.Y}, z: {point.Z}");
            }
        }
        
        static void calculatePoints()
        {
            Calculator calculator = new Calculator();
            Informer informer = new Informer();
            
            Point p1 = new Point(1.7m, 2.2m, 1.4m);
            Point p2 = new Point(1.5m, 3.5m, 2.5m);
            
            // informer.PrintToConsole(p1);
            
            calculator.PrintToConsole(p1);
            calculator.PrintToConsole(p2);
            calculator.PrintToConsole(p1, p2);
            calculator.PrintToConsole("Program is finished");
        }
    }
}