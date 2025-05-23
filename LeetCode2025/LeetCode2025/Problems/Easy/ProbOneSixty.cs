using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProbOneSixty : ProblemBase
    {

        public ListNode ListA { get; set; }
        public ListNode ListB { get; set; }

        public ProbOneSixty(int example)
        {
            switch (example)
            {
                case 1:
                    ListA = new ListNode(4);
                    ListB = new ListNode(5);

                    ListA.next = new ListNode(1);
                    ListA.next.next = new ListNode(8);
                    ListA.next.next.next = new ListNode(4);
                    ListA.next.next.next.next = new ListNode(5);

                    ListB.next = new ListNode(6);
                    ListB.next.next = new ListNode(1);
                    ListB.next.next.next = ListA.next.next;

                    break;
                default:
                    throw new Exception($"Example: {example} not found!");
            }
        }

        public void RunProblem()
        {
            ListNode? result = Solve(true);

            if(result == null)
            {
                Console.WriteLine("No intersection.");
            }
            else
            {
                Console.WriteLine($"Intersection found at: {result.val}");
            }
        }

        private ListNode Solve(bool dummy)
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();

            ListNode? A = ListA;
            ListNode? B = ListB;

            while(A != null)
            {
                visited.Add(A);
                A = A.next;
            }

            while(B != null)
            {
                if (visited.Contains(B)) return B;
                B = B.next;
            }

            return null;
        }
    }
}
