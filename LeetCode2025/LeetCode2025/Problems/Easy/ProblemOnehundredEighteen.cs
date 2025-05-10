using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredEighteen : ProblemBase
    {
        public int NumRows { get; set; }

        public ProblemOnehundredEighteen(int numRows)
        {
            NumRows = numRows;
        }

        public void RunProblem()
        {
            var triangle = Solve();

            foreach (var row in triangle)
            {
                Console.WriteLine(ToString(row));
            }
        }

        private IList<IList<int>> Solve()
        {
            var triangle = new List<IList<int>>();

            IList<int> prevRow = new List<int>();

            for (int r = 0; r < NumRows; r++)
            {
                var row = new List<int>(new int[r + 1]);
                triangle.Add(row);

                row[0] = 1;
                row[row.Count - 1] = 1;

                if (r > 1)
                {
                    row[1] = r;
                    row[row.Count - 2] = r;
                }

                if (r > 3)
                {
                    var mid = r / 2;

                    for (int i = 2; i <= mid; i++)
                    {
                        int val = prevRow[i - 1] + prevRow[i];

                        row[i] = val;
                        row[row.Count - 1 - i] = val;
                    }
                }

                prevRow = row;
            }

            return triangle;
        }
    }
}