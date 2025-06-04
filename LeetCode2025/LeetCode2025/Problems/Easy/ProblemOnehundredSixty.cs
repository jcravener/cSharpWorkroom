using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredSixty : ProblemBase
    {
        public ListNode ListA { get; set; }
        public ListNode ListB { get; set; }

        public ProblemOnehundredSixty(int example)
        {
            switch (example)
            {
                case 1:
                    ListA = new ListNode(4);
                    ListA.next = new ListNode(1);
                    ListA.next.next = new ListNode(8);
                    ListA.next.next.next = new ListNode(4);
                    ListA.next.next.next.next = new ListNode(5);
                    ListB = new ListNode(5);
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
            ListNode? result = Solve();
            
            if(result != null)
            {
                Console.WriteLine($"Intersection at {result.val}");
            }
            else
            {
                Console.WriteLine("No intersection.");
            }
        }

        private ListNode? Solve()
        {
            ListNode? nodeA = ListA;
            ListNode? nodeB = ListB;

            while (nodeA != nodeB)
            {
                nodeA = nodeA != null ? nodeA.next : ListB;

                nodeB = nodeB != null ? nodeB.next : ListA;
            }

            return nodeA;
        }

        private ListNode? Solve(bool dummy)
        {
            ListNode? nodeA = ListA;
            ListNode? nodeB = ListB;

            HashSet<ListNode> records = new();

            while(nodeA != null)
            {
                records.Add(nodeA);

                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                if(records.Contains(nodeB)) return nodeB;

                nodeB = nodeB.next;
            }

            return null;
        }
    }
}
