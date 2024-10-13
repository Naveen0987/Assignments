using System;
using System.Collections.Generic;

public class FloydWarshall
{
    public static void Main()
    {
        int[,] graph = new int[,]
        {
            {0, 5, int.MaxValue, 10},
            {int.MaxValue, 0, 3, int.MaxValue},
            {int.MaxValue, int.MaxValue, 0, 1},
            {int.MaxValue, int.MaxValue, int.MaxValue, 0}
        };

        int vertices = graph.GetLength(0);

        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (graph[i, k] + graph[k, j] < graph[i, j])
                    {
                        graph[i, j] = graph[i, k] + graph[k, j];
                    }
                }
            }
        }

        Console.WriteLine("Shortest distances between all pairs of vertices:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write(graph[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}