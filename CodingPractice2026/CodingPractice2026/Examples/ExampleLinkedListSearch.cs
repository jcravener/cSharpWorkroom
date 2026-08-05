using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice2026.Examples
{
    public class ExampleLinkedListSearch : ExampleBase
    {
        public ListNode? Head {  get; }

        private int Value { get; }

        public ExampleLinkedListSearch(int[] arr, int val)
        {
            Value = val;

            if (arr.Length == 0)
                throw new Exception("Array cannot be empty.");

            Head = new ListNode(arr[0]);
            ListNode tail = Head;

            HashSet<int> added = new();
            added.Add(arr[0]);

            for(int i = 1; i < arr.Length; i++)
            {
                if (added.Contains(arr[i]))
                    throw new Exception("Linked list cannot have duplicate values");
                
                tail.Next = new ListNode(arr[i]);
                tail = tail.Next;
            }
        }

        public void RunProblem()
        {
            ListNode? current = Head;

            int counter = 0;
            
            while(current != null)
            {
                if (Value == current.Value)
                {
                    Console.WriteLine($"Found {Value} at the number {counter} node.");
                    break;
                }
                counter++;

                current = current.Next;
            }

            if(current == null)
                Console.WriteLine($"Value {Value} not in linked list.");
        }
    }
}
