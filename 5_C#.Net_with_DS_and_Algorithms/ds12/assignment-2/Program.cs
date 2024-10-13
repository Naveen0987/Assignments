using System;

class RatInMaze
{
    static readonly int[,] maze =
    {
        {1, 1, 1, 0, 1, 1, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 0, 1},
        {0, 0, 0, 0, 0, 1, 0, 1},
        {1, 1, 1, 1, 0, 1, 1, 1},
        {1, 0, 0, 0, 0, 1, 0, 0},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 1}
    };

    static bool SolveMaze(int x, int y)
    {
        if (x == 7 && y == 7 && maze[x, y] == 1)
        {
            Console.WriteLine("Solution found!");
            return true;
        }

        if (!IsSafe(x, y))
        {
            return false;
        }

        if (SolveMaze(x + 1, y) || SolveMaze(x, y + 1) || SolveMaze(x - 1, y) || SolveMaze(x, y - 1))
        {
            return true;
        }

        Console.WriteLine("Backtracking...");
        return false;
    }

    static bool IsSafe(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8 && maze[x, y] == 1;
    }

    static void PrintMaze()
    {
        Console.WriteLine("Maze:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(maze[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Main()
    {
        PrintMaze();
        if (SolveMaze(0, 0))
        {
            Console.WriteLine("Maze solved successfully!");
        }
        else
        {
            Console.WriteLine("No solution found.");
        }
    }
}