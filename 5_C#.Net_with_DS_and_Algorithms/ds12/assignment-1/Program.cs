using System;

class RatInMaze
{
    static int[,] maze = {
        { 1, 0, 0, 0 },
        { 1, 1, 0, 1 },
        { 1, 1, 0, 0 },
        { 0, 1, 1, 1 }
    };

    static int[,] solution = new int[4, 4];

    static bool SolveMaze(int x, int y)
    {
        if (x == 3 && y == 3 && maze[x, y] == 1)
        {
            solution[x, y] = 1;
            return true;
        }

        if (IsSafe(x, y))
        {
            if (solution[x, y] == 1)
                return false;

            solution[x, y] = 1;

            if (SolveMaze(x + 1, y))
                return true;

            if (SolveMaze(x, y + 1))
                return true;

            if (SolveMaze(x - 1, y))
                return true;

            if (SolveMaze(x, y - 1))
                return true;

            solution[x, y] = 0;
            return false;
        }

        return false;
    }

    static bool IsSafe(int x, int y)
    {
        return (x >= 0 && x < 4 && y >= 0 && y < 4 && maze[x, y] == 1);
    }

    static void PrintSolution()
    {
       Console.WriteLine("Solution");

        for (int i = 0; i < 4; i++)
        {
            
            for (int j = 0; j < 4; j++)
            {
                Console.Write(solution[i, j] + " ");
            }
            Console.WriteLine();

        }
        
    }

    public static void Main()
    {
        if (SolveMaze(0, 0))
            PrintSolution();
        else
            Console.WriteLine("No solution found.");
    }
}
