using System;
using System.Collections.Generic;
using System.Linq;

class Edge
{
    public int Source;
    public int Destination;
    public int Weight;
}

class Program
{
    static void Main()
    {
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        var shortestDistances = BellmanFord(edges, 4, 0);

        Console.WriteLine("Shortest distances from vertex 0:");
        for (int i = 0; i < shortestDistances.Count; i++)
        {
            Console.WriteLine($"Vertex {i}: {shortestDistances[i]}");
        }
    }

    static List<int> BellmanFord(List<Edge> edges, int vertices, int startVertex)
    {
        List<int> shortestDistances = new List<int>(new int[vertices]);

        for (int i = 0; i < vertices; i++)
        {
            shortestDistances[i] = int.MaxValue;
        }

        shortestDistances[startVertex] = 0;

        for (int i = 0; i < vertices - 1; i++)
        {
            foreach (var edge in edges)
            {
                if (shortestDistances[edge.Source] + edge.Weight < shortestDistances[edge.Destination])
                {
                    shortestDistances[edge.Destination] = shortestDistances[edge.Source] + edge.Weight;
                }
            }
        }

        foreach (var edge in edges)
        {
            if (shortestDistances[edge.Source] + edge.Weight < shortestDistances[edge.Destination])
            {
                Console.WriteLine("Negative-weight cycle detected");
                return null;
            }
        }

        return shortestDistances;
    }
}