using System;

namespace CodingPractice2026.Examples
{
    public class ExampleBase
    {
        public ExampleBase()
        {
            Console.WriteLine();
            Console.WriteLine($" ==== Running: {this.GetType().Name} ==== ");
        }
    }
}
