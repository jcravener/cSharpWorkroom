using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredFourtyone : ProblemBase
    {

        ListNode Head { get; set; }
        
        public ProblemOnehundredFourtyone(int example)
        {
            switch (example)
            {
                case 1:
                    Head = new ListNode(3);
                    Head.next = new ListNode(2);
                    Head.next.next = new ListNode(0);
                    Head.next.next.next = new ListNode(-4);
                    Head.next.next.next.next = Head.next;
                    break;
                
                default:
                    throw new Exception($"Example: {example} unknown.");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(Detect());
        }

        private bool Detect()
        {
            ListNode? slow = Head;
            ListNode? fast = Head;
            
            while(fast != null && fast.next != null)
            {
                slow = slow?.next;
                fast = fast?.next?.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
