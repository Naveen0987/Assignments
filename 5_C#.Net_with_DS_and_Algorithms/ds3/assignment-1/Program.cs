public class Node
{
    public int Value;
    public Node? Left;
    public Node? Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class Program
{
    public static int IsBalanced(Node? root)
    {
        if (root == null)
        {
            return 0;
        }

        int leftHeight = IsBalanced(root.Left);
        if (leftHeight == -1)
        {
            return -1;
        }

        int rightHeight = IsBalanced(root.Right);
        if (rightHeight == -1)
        {
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }

        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public static void Main()
    {
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);

        int balance = IsBalanced(root);
        if (balance == -1)
        {
            Console.WriteLine("clTree is not balanced");
        }
        else
        {
            Console.WriteLine("After checking the given tree is balanced");
        }
    }
}