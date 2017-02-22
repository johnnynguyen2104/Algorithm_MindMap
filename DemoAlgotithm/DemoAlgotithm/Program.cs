using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoAlgotithm.BinaryTree;

namespace DemoAlgotithm
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeStructure<int> binaryTreeStructure = new BinaryTreeStructure<int>();

            binaryTreeStructure.Insert(new BinaryNode<int>(24));
            binaryTreeStructure.Insert(new BinaryNode<int>(20));
            binaryTreeStructure.Insert(new BinaryNode<int>(31));
            binaryTreeStructure.Insert(new BinaryNode<int>(7));
            binaryTreeStructure.Insert(new BinaryNode<int>(22));
            binaryTreeStructure.Insert(new BinaryNode<int>(6));
            binaryTreeStructure.Insert(new BinaryNode<int>(21));
            binaryTreeStructure.Insert(new BinaryNode<int>(23));

            Console.WriteLine(binaryTreeStructure.FindMaxNode().Value);

            Console.WriteLine(binaryTreeStructure.FindMinNode().Value);
            Console.ReadLine();
        }
    }
}
