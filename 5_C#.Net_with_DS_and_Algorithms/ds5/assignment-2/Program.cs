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

        var shortestDistances = Dijkstra(edges, 4, 0);
        Console.WriteLine("This is the Dijkstra Algorithm");

        Console.WriteLine("Shortest distances from vertex 0:");
        foreach (var distance in shortestDistances)
        {
            Console.WriteLine($"Vertex {shortestDistances.IndexOf(distance)}: {distance}");
        }
    }

    static List<int> Dijkstra(List<Edge> edges, int vertices, int startVertex)
    {
        List<int> shortestDistances = new List<int>(new int[vertices]);
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            shortestDistances[i] = int.MaxValue;
        }

        shortestDistances[startVertex] = 0;

        for (int i = 0; i < vertices - 1; i++)
        {
            int minDistanceVertex = -1;
            int minDistance = int.MaxValue;

            for (int j = 0; j < vertices; j++)
            {
                if (!visited[j] && shortestDistances[j] < minDistance)
                {
                    minDistance = shortestDistances[j];
                    minDistanceVertex = j;
                }
            }

            visited[minDistanceVertex] = true;

            foreach (var edge in edges)
            {
                if (edge.Source == minDistanceVertex && !visited[edge.Destination] && shortestDistances[minDistanceVertex] + edge.Weight < shortestDistances[edge.Destination])
                {
                    shortestDistances[edge.Destination] = shortestDistances[minDistanceVertex] + edge.Weight;
                }
            }
        }


        return shortestDistances;
        
    }
}