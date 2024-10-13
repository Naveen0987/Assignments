using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Dictionary<string, List<Tuple<string, int>>>
            {
                {"A", new List<Tuple<string, int>> { Tuple.Create("B", 1), Tuple.Create("C", 3) }},
                {"B", new List<Tuple<string, int>> { Tuple.Create("A", 1), Tuple.Create("C", 2) }},
                {"C", new List<Tuple<string, int>> { Tuple.Create("A", 3), Tuple.Create("B", 2) }}
            };

            if (graph == null || graph.Count == 0)
            {
                Console.WriteLine("Graph is empty");
                return;
            }

            var startNode = "A";
            var distancesDijkstra = Dijkstra(graph, startNode);

            Console.WriteLine("Dijkstra's algorithm:");
            foreach (var node in distancesDijkstra)
            {
                Console.WriteLine($"Distance from {startNode} to {node.Key}: {node.Value}");
            }

            var allPairsDistances = FloydWarshall(graph);

            Console.WriteLine("\nFloyd-Warshall algorithm:");
            foreach (var fromNode in allPairsDistances.Keys)
            {
                foreach (var toNode in allPairsDistances[fromNode].Keys)
                {
                    Console.WriteLine($"Distance from {fromNode} to {toNode}: {allPairsDistances[fromNode][toNode]}");
                }
            }
        }

        // Dijkstra's algorithm
        static Dictionary<string, int> Dijkstra(Dictionary<string, List<Tuple<string, int>>> graph, string startNode)
        {
            var distances = new Dictionary<string, int>();
            var unsettledNodes = new List<string>(graph.Keys);

            foreach (var node in graph)
            {
                distances[node.Key] = int.MaxValue;
            }

            distances[startNode] = 0;

            while (unsettledNodes.Count > 0)
            {
                var currentNode = GetLowestDistanceNode(distances, unsettledNodes);
                unsettledNodes.Remove(currentNode);

                foreach (var neighbor in graph[currentNode])
                {
                    var distance = distances[currentNode] + neighbor.Item2;

                    if (distance < distances[neighbor.Item1])
                    {
                        distances[neighbor.Item1] = distance;
                    }
                }
            }

            return distances;
        }

        // Floyd-Warshall algorithm
        static Dictionary<string, Dictionary<string, int>> FloydWarshall(Dictionary<string, List<Tuple<string, int>>> graph)
        {
            var nodes = graph.Keys.ToList();
            var distances = new Dictionary<string, Dictionary<string, int>>();

            foreach (var fromNode in nodes)
            {
                distances[fromNode] = new Dictionary<string, int>();
                foreach (var toNode in nodes)
                {
                    if (fromNode == toNode)
                    {
                        distances[fromNode][toNode] = 0;
                    }
                    else
                    {
                        var edge = graph[fromNode].FirstOrDefault(e => e.Item1 == toNode);
                        distances[fromNode][toNode] = edge != null ? edge.Item2 : int.MaxValue;
                    }
                }
            }

            foreach (var k in nodes)
            {
                foreach (var i in nodes)
                {
                    foreach (var j in nodes)
                    {
                        if (distances[i][k] != int.MaxValue && distances[k][j] != int.MaxValue)
                        {
                            distances[i][j] = Math.Min(distances[i][j], distances[i][k] + distances[k][j]);
                        }
                    }
                }
            }

            return distances;
        }

        static string GetLowestDistanceNode(Dictionary<string, int> distances, List<string> unsettledNodes)
        {
            var lowestDistanceNode = "";
            var lowestDistance = int.MaxValue;

            foreach (var node in unsettledNodes)
            {
                if (distances[node] < lowestDistance)
                {
                    lowestDistanceNode = node;
                    lowestDistance = distances[node];
                }
            }

            return lowestDistanceNode;
        }
    }
}