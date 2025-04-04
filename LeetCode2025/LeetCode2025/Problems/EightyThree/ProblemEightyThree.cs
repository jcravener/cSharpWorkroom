using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.EightyThree
{
    public class ProblemEightyThree : ProblemBase
    {
        public ListNode Head { get; set; }

        public ProblemEightyThree(ListNode node)
        {
            Head = node;
        }

        public void RunProblem()
        {
            var node = Solve();

            while(node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }

        private ListNode Solve()
        {
            if (Head == null) return Head;
            
            ListNode current = Head;
            ListNode lastNode = Head;
            ListNode returnNode = lastNode;

            while (current != null)
            {
                if(lastNode.val != current.val)
                {
                    lastNode.next = current;
                    lastNode = lastNode.next;
                }

                current = current.next;
            }

            //  This soluton worked, but would not this set lastNode.next to null? 
            //
            if(lastNode.next != current)
            {
                lastNode.next = current;
            }

            return returnNode;
        }
    }
}
