using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var graph = new Dictionary<char, List<char>>
        {
            {'A', new List<char> {'B', 'C'}},
            {'B', new List<char> {'A', 'D', 'E'}},
            {'C', new List<char> {'A', 'F'}},
            {'D', new List<char> {'B'}},
            {'E', new List<char> {'B', 'F'}},
            {'F', new List<char> {'C', 'E'}}
        };

        Console.WriteLine("BFS Traversal:");
        Console.WriteLine("--------------");

        var result = BFS(graph, 'A');
        Console.WriteLine(string.Join(" ", result));

        Console.WriteLine("--------------");
    }

    public static List<char> BFS(Dictionary<char, List<char>> graph, char start)
    {
        var visited = new HashSet<char>();
        var queue = new Queue<char>();
        var result = new List<char>();

        queue.Enqueue(start);

        while (queue.Any())
        {
            var node = queue.Dequeue();

            if (!visited.Contains(node))
            {
                result.Add(node);
                visited.Add(node);

                foreach (var neighbor in graph[node].Where(neighbor => !visited.Contains(neighbor)))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
}