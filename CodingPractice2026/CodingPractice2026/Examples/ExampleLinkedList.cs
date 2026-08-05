using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice2026.Examples
{
    public class ExampleLinkedList : ExampleBase
    {
        public ListNode? Head {  get; }

        public ExampleLinkedList(int[] arr)
        {
            Head = new ListNode(arr[0]);
            ListNode tail = Head;

            for(int i = 1; i < arr.Length; i++)
            {
                tail.Next = new ListNode(arr[i]);
                tail = tail.Next;
            }
        }

        public void RunProblem()
        {
            ListNode? current = Head;
            
            while(current != null)
            {
                Console.Write(current.Value);
                if (current.Next != null)
                    Console.Write(" ");

                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}
