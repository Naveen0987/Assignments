using System;
using System.Collections.Generic;

class Program
{
    static void FindSubsets(int[] weights, int m, List<int> currentSubset, int index)
    {
        if (m == 0)
        {
            Console.Write("{ ");
            foreach (int weight in currentSubset)
            {
                Console.Write(weight + " ");
            }
            Console.WriteLine("}");
            return;
        }

        if (m < 0 || index == weights.Length) return;

        currentSubset.Add(weights[index]);
        FindSubsets(weights, m - weights[index], currentSubset, index + 1);

        currentSubset.RemoveAt(currentSubset.Count - 1);
        FindSubsets(weights, m, currentSubset, index + 1);
    }

    static void Main()
    {
        int[] weights = { 5, 10, 12, 13, 15, 18 };
        int m = 30;

        List<int> currentSubset = new List<int>();
        FindSubsets(weights, m, currentSubset, 0);
    }
}
