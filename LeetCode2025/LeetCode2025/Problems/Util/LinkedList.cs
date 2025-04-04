using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Util
{
    public class LinkedList
    {
        public ListNode? head { get; set; }

        public ListNode? tail { get; set; }

        public LinkedList(int[] vals)
        {
            head = null;
            tail = null;

            foreach (var val in vals)
            {
                ListNode node = new ListNode(val);

                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }
            }
        }

        public void TraverseForward()
        {
            var tmpNode = head;

            while (tmpNode != null)
            {
                Console.WriteLine(tmpNode.val);
                tmpNode = tmpNode.next;
            }
        }
    }
}
