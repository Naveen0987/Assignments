using System;
using System.Text;

class Program
{
    static void Main()
    {
        string strA = "aabcdefghij";
        string strB = "ecdgi";

        string lcs = FindLCS(strA, strB);

        Console.WriteLine("LCS of \"{0}\" and \"{1}\" is \"{2}\"", strA, strB, lcs);
    }

    static string FindLCS(string strA, string strB)
    {
        int[,] dp = new int[strA.Length + 1, strB.Length + 1];

        for (int i = 0; i <= strA.Length; i++)
        {
            for (int j = 0; j <= strB.Length; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                }
                else if (strA[i - 1] == strB[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        int iIndex = strA.Length;
        int jIndex = strB.Length;
        StringBuilder lcsBuilder = new StringBuilder();

        while (iIndex > 0 && jIndex > 0)
        {
            if (strA[iIndex - 1] == strB[jIndex - 1])
            {
                lcsBuilder.Insert(0, strA[iIndex - 1]);
                iIndex--;
                jIndex--;
            }
            else if (dp[iIndex - 1, jIndex] > dp[iIndex, jIndex - 1])
            {
                iIndex--;
            }
            else
            {
                jIndex--;
            }
        }

        return lcsBuilder.ToString();
    }
}