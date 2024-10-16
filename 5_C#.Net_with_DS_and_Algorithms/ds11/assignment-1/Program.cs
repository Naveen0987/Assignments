﻿using System;

class Program
{
    static int OptimalBSTCost(int[] freq, int n)
    {
        int[,] cost = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        for (int L = 2; L <= n; L++)
        {
            for (int i = 0; i <= n - L; i++)
            {
                int j = i + L - 1;
                cost[i, j] = int.MaxValue;

                for (int r = i; r <= j; r++)
                {
                    int c = ((r > i) ? cost[i, r - 1] : 0) +
                            ((r < j) ? cost[r + 1, j] : 0) +
                            Sum(freq, i, j);

                    if (c < cost[i, j])
                    {
                        cost[i, j] = c;
                    }
                }
            }
        }

        return cost[0, n - 1];
    }

    static int Sum(int[] freq, int i, int j)
    {
        int s = 0;
        for (int k = i; k <= j; k++)
        {
            s += freq[k];
        }
        return s;
    }

    static void Main()
    {
        int[] keys = { 10, 20, 30, 40 };
        int[] freq = { 4, 2, 6, 3 };
        int n = keys.Length;

        int cost = OptimalBSTCost(freq, n);

        Console.WriteLine("Cost of the Optimal Binary Search Tree: " + cost);
    }
}