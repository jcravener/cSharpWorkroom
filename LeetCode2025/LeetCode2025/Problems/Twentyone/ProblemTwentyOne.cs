using LeetCode2025.Problems.Two;using System;
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
            ListNode tmpNode = new ListNode();

            while (List1 != null && List2 != null)
            {
                if(List1.val <= List2.val)
                {
                    
                }
            }
        }
        
    }
}
