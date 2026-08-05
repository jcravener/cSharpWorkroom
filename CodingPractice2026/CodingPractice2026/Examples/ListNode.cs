using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice2026.Examples
{
    public class ListNode
    {
        public ListNode? Next { get; set; }
        public int Value { get; }

        public ListNode(int val)
        {
            Value = val;
            Next = null;
        }
    }
}
