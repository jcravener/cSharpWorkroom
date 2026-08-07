using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
  static class Utils
  {
    public static int[] RandomIntArray(int length, int start = 0, int finish = 99)
    {
      var rand = new Random();

      return Enumerable.Range(0, length)
        .Select(_ => rand.Next(start, finish))
        .ToArray();
    }
  }
}