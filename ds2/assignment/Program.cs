public class Linear
{
    static void Main(string[] args)
    {
        int[] a = {5, 8, 4, 3, 0, 1, 7, 6, 10, 50, 40, 60, 20};
        int target = 40;
        bool found =false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == target)
            {
                Console.WriteLine("element found at index position :"+i);
                found=true;
                 break; 
            }
        }
            if(!found){
                Console.WriteLine("element not found");
            }
        }
    }
