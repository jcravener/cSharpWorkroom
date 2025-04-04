using LeetCode2025.Problems.Two;
using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.twentyone
{
    public class ProblemTwentyOne : ProblemBase
    {

        public ListNode List1 { get; set; }
        public ListNode List2 { get; set; }

        public ProblemTwentyOne(int[] list1, int[] list2)
        {
            var l1 = new LinkedList(list1);
            var l3 = new LinkedList(list2);

            List1 = l1.head;
            List2 = l3.head;

        }

        public void RunProblem()
        {
            ListNode head = Solve();

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
        
        public ListNode Solve()
        {
            ListNode dummyNode = new ListNode(-1);
            ListNode current = dummyNode;

            while (List1 != null && List2 != null)
            {
                if(List1.val <= List2.val)
                {
                    current.next = List1;
                    List1 = List1.next;
                }
                else
                {
                    current.next = List2;
                    List2 = List2.next;
                }

                current = current.next;
            }

            if(List1 != null)
            {
                current.next = List1;
            }

            if(List2 != null)
            {
                current.next = List2;
            }

            return dummyNode.next;
        }
    }
}
