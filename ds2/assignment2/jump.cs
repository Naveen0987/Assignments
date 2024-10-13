using System;

class Program
{
    static void Main() {
    
        int[] numbers = { 0, 1, 3, 4, 5, 6, 7, 8, 10, 20, 40, 50, 60 };
        int target = 40;

        int result = JumpSearch(numbers, target);

        if (result != -1)
        {
            Console.WriteLine("Element Found " + target + " at index " + result);
        }
        else
        {
            Console.WriteLine("Element Not found");
        }
    }

    static int JumpSearch(int[] arr, int target)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);

        int start = 0;
        while (start < n)
        {
            int end = Math.Min(start + step, n);

            if (arr[end - 1] >= target)
            {
                for (int i = start; i < end; i++)
                {
                    if (arr[i] == target)
                    {
                        return i;
                    }
                }
            }

            start =start+ step;
        }

        return -1;
    }
}