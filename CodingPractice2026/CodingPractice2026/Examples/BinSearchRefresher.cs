using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class BinSearchRefresher : ExampleBase
    {

      private int BinSearch(int[] arr, int val)
      {
        // Establish the pointers
        int start = 0
        int end = arr.Length - 1;

        // search the interval
        // invariant: if the value is found, it's within start and and
        while(start <= end)
        {
          // establish mid
          int mid = start + (end - start) / 2;

          // check if you found the value
          if(val == arr[mid])
          {
            return mid;
          }

          // shift end to 1 less than mid to check left half
          if(val < arr[mid])
            end = mid - 1;
          else // shift start to 1 past mid to check right half
            start = mid + 1
        }

        return -1;
      } 
    }
}