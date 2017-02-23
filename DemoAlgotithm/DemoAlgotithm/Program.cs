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

            binaryTreeStructure.Insert(new BinaryNode<int>(35));
            binaryTreeStructure.Insert(new BinaryNode<int>(33));
            binaryTreeStructure.Insert(new BinaryNode<int>(42));
            binaryTreeStructure.Insert(new BinaryNode<int>(10));
            binaryTreeStructure.Insert(new BinaryNode<int>(14));
            binaryTreeStructure.Insert(new BinaryNode<int>(19));
            binaryTreeStructure.Insert(new BinaryNode<int>(27));
            binaryTreeStructure.Insert(new BinaryNode<int>(44));
            binaryTreeStructure.Insert(new BinaryNode<int>(26));
            binaryTreeStructure.Insert(new BinaryNode<int>(32));

            Console.WriteLine(binaryTreeStructure.FindMaxNode().Value);

            Console.WriteLine(binaryTreeStructure.FindMinNode().Value);
            Console.ReadLine();
        }
    }
}
