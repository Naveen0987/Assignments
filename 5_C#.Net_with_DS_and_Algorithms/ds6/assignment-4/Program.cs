using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 1, 2, 3 };
        int[] result = FindNonRepeatingElements(arr);
        Console.WriteLine("Non-repeating elements: " + result[0] + ", " + result[1]);
    }

    static int[] FindNonRepeatingElements(int[] arr)
    {
        int xor = 0;
        foreach (int num in arr)
        {
            xor ^= num;
        }

        int rightmostSetBit = xor & -xor;
        int num1 = 0, num2 = 0;
        foreach (int num in arr)
        {
            if ((num & rightmostSetBit) != 0)
            {
                num1 ^= num;
            }
            else
            {
                num2 ^= num;
            }
        }

        return new int[] { num1, num2 };
    }
}