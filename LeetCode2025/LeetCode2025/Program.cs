﻿using LeetCode2025.Problems.EightyThree;
using LeetCode2025.Problems.EigthtyEight;
using LeetCode2025.Problems.FiftyEight;
using LeetCode2025.Problems.Fourteen;
using LeetCode2025.Problems.Nine;
using LeetCode2025.Problems.NinetyFour;
using LeetCode2025.Problems.OneHundred;
using LeetCode2025.Problems.OneHundredOne;
using LeetCode2025.Problems.SixtySeven;
using LeetCode2025.Problems.SixtySix;
using LeetCode2025.Problems.Thirteen;
using LeetCode2025.Problems.ThirtyFive;
using LeetCode2025.Problems.Three;
using LeetCode2025.Problems.Twenty;
using LeetCode2025.Problems.Twentyeight;
using LeetCode2025.Problems.twentyone;
using LeetCode2025.Problems.TwentySeven;
using LeetCode2025.Problems.TwentySix;
using LeetCode2025.Problems.Two;
using LeetCode2025.Problems.Util;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var two = new ProblemTwo();
            two.RunProblem();

            var three = new ProblemThree("tmmzuxt");
            three.RunProblem();

            var nine = new ProblemNine(10);
            nine.RunProblem();

            var thirteen = new ProblemThriteen("CM");
            thirteen.RunProblem();

            var twenty = new ProblemTwenty("([])");
            twenty.RunProblem();

            twenty.Input = "()";
            twenty.RunProblem();

            twenty.Input = "(]";
            twenty.RunProblem();

            twenty.Input = "([)]";
            twenty.RunProblem();

            twenty.Input = "()[]{}";
            twenty.RunProblem();

            twenty.Input = "((";
            twenty.RunProblem();

            twenty.Input = "]]";
            twenty.RunProblem();

            twenty.Input = "]";
            twenty.RunProblem();

            var fourteen = new ProblemFourteen(["flower", "flow", "flight"]);
            fourteen.RunProblem();

            fourteen.Strings = ["dog", "racecar", "car"];
            fourteen.RunProblem();

            var twentyOne = new ProblemTwentyOne(new int[]{ 1,2,4 }, new int[]{ 2,3,4 });
            twentyOne.RunProblem();

            var twentSix = new ProblemTwentySix(new int[]{ 1, 1, 2 });
            twentSix.RunProblem();

            twentSix.Nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            twentSix.RunProblem();

            var twentySeven = new ProblemTwentySeven(new int[] { 3, 2, 2, 3 }, 3);
            twentySeven.RunProblem();

            twentySeven.Nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            twentySeven.Value = 2;
            twentySeven.RunProblem();

            var twentyEight = new ProblemTwentyEight("sadbutsad", "sad");
            twentyEight.RunProblem();
            
            twentyEight.Haystack = "leetcode";
            twentyEight.Needle = "leeto";
            twentyEight.RunProblem();

            twentyEight.Haystack = "a";
            twentyEight.Needle = "a";
            twentyEight.RunProblem();

            var thirtyFive = new ProblemThirtyFive([1, 3, 5, 6], 5);
            thirtyFive.RunProblem();

            thirtyFive.Nums = new int[] { 1, 3, 5, 6 };
            thirtyFive.Target = 2;
            thirtyFive.RunProblem();

            thirtyFive.Nums = new int[] { 1, 3, 5, 6 };
            thirtyFive.Target = 7;
            thirtyFive.RunProblem();

            thirtyFive.Nums = new int[] { 1 };
            thirtyFive.Target = 1;
            thirtyFive.RunProblem();

            var problemFiftyEight = new ProblemFiftyEight("Hello World");
            problemFiftyEight.RunProblem();

            problemFiftyEight.S = "   fly me   to   the moon  ";
            problemFiftyEight.RunProblem();

            problemFiftyEight.S = "luffy is still joyboy";
            problemFiftyEight.RunProblem();

            var problemSixtySix = new ProblemSixtySix([1,2,3]);
            problemSixtySix.RunProblem();

            var problemSixtySeven = new ProblemSixtySeven("100", "110010");
            problemSixtySeven.RunProblem();

            var list = new LinkedList([1, 1, 2, 3, 3, 3, 3, 3]);

            var problemEightyThree = new ProblemEightyThree(list.head);
            problemEightyThree.RunProblem();

            var problemEightyEight = new ProblemEightyEight([1, 2, 3, 0, 0, 0], 3, [2, 5, 6], 3);
            problemEightyEight.RunProblem();

            problemEightyEight.Nums1 = [1];
            problemEightyEight.Nums2 = [];
            problemEightyEight.M = 1;
            problemEightyEight.N = 0;
            problemEightyEight.RunProblem();

            problemEightyEight.Nums1 = [0];
            problemEightyEight.Nums2 = [1];
            problemEightyEight.M = 0;
            problemEightyEight.N = 1;
            problemEightyEight.RunProblem();

            problemEightyEight.Nums1 = [2, 0];
            problemEightyEight.Nums2 = [1];
            problemEightyEight.M = 1;
            problemEightyEight.N = 1;
            problemEightyEight.RunProblem();

            problemEightyEight.Nums1 = [4, 5, 6, 0, 0, 0];
            problemEightyEight.Nums2 = [1,2,3];
            problemEightyEight.M = 3;
            problemEightyEight.N = 3;
            problemEightyEight.RunProblem();

            var problemNinetyFour = new ProblemNinetyFour([1, null, 2, 3]);
            problemNinetyFour.RunProblem();

            var problemOneHundred = new ProblemOneHundred(2);
            problemOneHundred.RunProblem();

            var problemOnehundredOne = new ProblemOneHundredOne(1);
            problemOnehundredOne.RunProblem();
        }
    }
}
