using System;

namespace binSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxRand = 100;
            //Random rand = new Random();
            int maxLen = 19;

            int[] a = CreateArray(maxLen, maxRand);
            Array.Sort(a);
            PrintArray(a, true);
            
            RandomElement re = GetRandElement(a);
            PrintRandElement(re, true);

            int first = 0;
            int last = a.Length - 1;
            int mid = GetMid(first, last);
            Console.WriteLine($"first: {first} mid: {mid} last: {last}");
            PrintArray(a[first..(mid + 1)], true);
            PrintArray(a[(mid + 1)..(last + 1)], true);
            Console.WriteLine($"mid val: {a[mid]}");

            Console.WriteLine();
            if (re.val < a[mid])
            {
                PrintArray(a[first..(mid + 1)], true);

                //first = first;
                last = mid;
                mid = GetMid(first, last);
                
                Console.WriteLine($"new: first: {first} mid: {mid} last: {last}");
                Console.WriteLine($"mid val: {a[mid]}");
            }
            else if (re.val > a[mid])
            {
                PrintArray(a[(mid + 1)..(last + 1)], true);

                first = mid + 1;
                //last = last;
                mid = GetMid(first, last);

                Console.WriteLine($"new: first: {first} mid: {mid} last: {last}");
                Console.WriteLine($"mid val: {a[mid]}");
            }
            else
            {
                Console.WriteLine($"{re.val} is in {mid}");
            }
        }

        public static int[] CreateArray(int maxLen, int maxRand)
        {
            int[] a = new int[maxLen];
            Random rand = new Random();
            for (int i = 0; i < maxLen; i++)
            {
                a[i] = rand.Next(maxRand);
            }

            return a;
        }

        public static void PrintArray(int[] a, bool newLine)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                if (i < a.Length - 1)
                {
                    Console.Write(' ');
                }
            }

            if (newLine)
            {
                Console.WriteLine();
            }
        }

        public static RandomElement GetRandElement(int[] a)
        {
            RandomElement re = new RandomElement();
            Random rand = new Random();
            re.index = rand.Next(a.Length - 1);
            re.val = a[re.index];
            return re;
        }

        public static void PrintRandElement(RandomElement re, bool newLine)
        {
            Console.WriteLine($"index: {re.index} value: {re.val}");
            if (newLine)
            {
                Console.WriteLine();
            }
        }

        public static int GetMid(int first, int last)
        {
            return last - ((last - first) / 2);
        }

    }

    public class RandomElement
    {
        public int index { get; set; }
        public int val { get; set; }
    }
}

