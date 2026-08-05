using System;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class ExampleBinSearch : ExampleBase
    {
        private int[] Input {get; set;}

        private int Value {get; set;}
        
        public ExampleBinSearch(int[] input, int val) : base()
        {
            Input = input;
            Array.Sort(Input);
            Value = val;
        }

        public void RunProblem()
        {
            Console.WriteLine(BinSearch(Value));
        }

        private int BinSearch(int val)
        {
            // invariant: if value exists in the arrary, it must lie withing interval
            int start = 0;
            int end = Input.Length - 1;

            while(start <= end) // while we are within the interval
            {
                int mid = start + (end - start) / 2; // valulate the mid point

                if(val == Input[mid]) // if the value is at the mid point retunt the index
                    return mid;

                if(val < Input[mid]) // if the value is left of the mid-value, shift end
                    end = mid - 1; // also shift left of the mid point since we know value is not at the mid
                else // since the value is not left of the mid-value, shit start
                    start = mid + 1;
            }

            return -1;
        }
   }
}
