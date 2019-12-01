using Hackerrank.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hackerrank
{
    /// <summary>
    /// Binary tree
    /// </summary>
    class Node
    {
        public int Data { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int value)
        {
            Data = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = { 1,2,3,4,5,6,7,8,9,10 };

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Bst(preOrder, i)} {i}");
            }


             NhanVien a = new NhanVien() { Name = "Sam Dia" };

            NhanVien b = a;
            b.Name = "Xay Lu";

           

            Console.WriteLine("Hellowold");
        }

        private static int Bst(int[] array, int x)
        {
            int left = 0, right = array.Length - 1;
            Stack<int> s = new Stack<int>();
            s.Push((left + right) / 2);

            while (s.Count != 0)
            {
                if (array[s.Peek()] == x)
                {
                    return 0;
                }
                else if (array[s.Peek()] < x)
                {
                    left = s.Pop() + 1;
                }
                else
                {
                    right = s.Pop() - 1;
                }

                if (left <= right)
                {
                    s.Push((left + right) / 2);
                }
            }

            //int left = 0, right = array.Length - 1;
            //int mid = (left + right) / 2;

            //while (mid != -1)
            //{
            //    if (array[mid] == x)
            //    {
            //        return 0;
            //    }
            //    else if (array[mid] < x)
            //    {
            //        left = mid + 1;
            //    }
            //    else
            //    {
            //        right = mid - 1;
            //    }

            //    if (left <= right)
            //    {
            //        mid = (left + right) / 2;
            //    }
            //    else
            //    {
            //        mid = -1;
            //    }
            //}

            return -1;
        }

        class NhanVien
        {
            public string Name { get; set; }
        }

        //static bool Bst(Node root, int target)
        //{
        //    Stack<Node> stackNode = new Stack<Node>();
        //    Node current = root;

        //    while (stackNode.Count > 0)
        //    {
        //        if (true)
        //        {

        //        }
        //    }

        //}
        
        static Node constructTree(int[] preorder)
        {
            Stack<Node> s = new Stack<Node>();
            Node root = new Node(preorder[0]);

            s.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                Node x = null;
                while (s.Count != 0 && preorder[i] > s.Peek().Data)
                {
                    x = s.Pop();
                }

                if (x != null)
                {
                    x.Right = new Node(preorder[i]);
                    s.Push(x.Right);
                }
                else
                {
                    s.Peek().Left = new Node(preorder[i]);
                    s.Push(s.Peek().Left);
                }
            }

            return root;
        }
    }
}
