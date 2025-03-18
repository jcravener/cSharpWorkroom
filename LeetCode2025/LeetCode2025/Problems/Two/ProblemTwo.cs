using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Two
{
    public class ProblemTwo
    {       
        public ProblemTwo() 
        { 
            Console.WriteLine($"Running: {this.GetType().Name}.");
        }
        
        public void RunProblem()
        {
            var list1 = new int[] { 9 };
            var list2 = new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 };

            var l1 = new LinkedList(list1);
            var l2 = new LinkedList(list2);

            BigInteger val1 = GetVal(l1.head);
            BigInteger val2 = GetVal(l2.head);

            BigInteger sum = val1+val2;

            ListNode head = null;

            if (sum == 0)
            {
                head = AdvanceNode(null, 0);
            }
            else
            {
                head = GetAnswer(head, sum);
            }

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        private static BigInteger GetVal(ListNode node)
        {
            BigInteger val = 0;
            int index = 0;

            while (node != null)
            {
                val += BigInteger.Pow(10, index) * node.val;
                node = node.next;
                index++;
            }

            return val;
        }

        private static ListNode AdvanceNode(ListNode? head, int val)
        {
            ListNode node = new ListNode(val);
            node.next = head;
            head = node;
            return head;
        }

        private static ListNode GetAnswer(ListNode? head, BigInteger sum)
        {
            foreach (char dig in sum.ToString())
            {
                int val = int.Parse(dig.ToString());

                head = AdvanceNode(head, val);
            }

            return head;
        }

        private static int GetPlace(int val)
        {
            return (int)Math.Floor(Math.Log10(val));
        }

        private static int GetDigit(int val, int place)
        {
            return (int)Math.Floor((val / (Math.Pow(10, place))));
        }

        private static int ReduceValue(int val, int digit, int place)
        {
            int reduction = (int)Math.Floor(Math.Pow(10, place)) * digit;

            return val - reduction;
        }

        private static ListNode GetAnswerMath(ListNode? head, int sum)
        {
            while (sum > 0)
            {
                int place = GetPlace(sum);
                int digit = GetDigit(sum, place);
                int newSum = ReduceValue(sum, digit, place);

                head = AdvanceNode(head, digit);

                if (place == 0)
                {
                    break;
                }

                if (newSum == 0 && place > 0)
                {
                    while (place > 0)
                    {
                        head = AdvanceNode(head, 0);
                        place--;
                    }

                    break;
                }

                int newPlace = GetPlace(newSum);

                if (newPlace != place - 1)
                {
                    for (int i = 1; i < place - newPlace; i++)
                    {
                        head = AdvanceNode(head, 0);
                    }
                }

                sum = newSum;
            }

            return head;
        }

    }
}
