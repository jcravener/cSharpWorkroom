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

            int midpoint;

            for (int i  = 1; i < NumRows; i++)
            {
                List<int> var = new(new int[i]);

                var[0] = 1; var[var.Count - 1] = 1;

                int adj = i - 1;

                if (i > 2)
                {
                    var[1] = adj; var[var.Count - 2] = adj;
                }

                triangle.Add(var);
            }

            IList<int> row = new List<int>();
            IList<int> prevRow = new List<int>();

            for (int r = 0; r < triangle.Count; r++)
            {
                row = triangle[r];

                if(r < 4) continue;
                prevRow = triangle[r - 1];
                
                midpoint = row.Count / 2;
                
                for(int i = 2; i < midpoint; i++)
                {
                    int val = prevRow[i-1] + prevRow[i];
                    row[i] = val;

                    int j = row.Count - 1;
                    row[j - i] = val;
                }

                if( row.Count%2 != 0 )
                {
                    row[midpoint] = prevRow[midpoint]*2;
                }
            }

            return triangle;
        }
    }
}