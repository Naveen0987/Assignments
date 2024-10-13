using System;

class NQueen
{
    static void Main()
    {
        int N = 4;
        int[,] board = new int[N, N];

        if (SolveNQueen(board, 0, N))
            PrintBoard(board, N);
        else
            Console.WriteLine("Solution does not exist.");
    }

    static bool SolveNQueen(int[,] board, int col, int N)
    {
        if (col >= N)
            return true;

        for (int row = 0; row < N; row++)
        {
            if (IsSafe(board, row, col, N))
            {
                board[row, col] = 1;

                if (SolveNQueen(board, col + 1, N))
                    return true;

                board[row, col] = 0;
            }
        }

        return false;
    }

    static bool IsSafe(int[,] board, int row, int col, int N)
    {
        for (int i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        for (int i = row, j = col; i < N && j >= 0; i++, j--)
            if (board[i, j] == 1)
                return false;

        for (int i = 0; i < row; i++)
            if (board[i, col] == 1)
                return false;

        return true;
    }

    static void PrintBoard(int[,] board, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }
}
