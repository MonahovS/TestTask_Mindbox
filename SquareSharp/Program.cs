using System;

namespace SquareSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SquareTests.RunTests())
            {
                Console.WriteLine("Have errors!");
            }
            else
            {
                Console.WriteLine("All ok.");
            }

            Console.ReadKey();
        }
    }
}
