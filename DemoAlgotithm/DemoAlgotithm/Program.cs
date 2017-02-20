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

            binaryTreeStructure.Insert(new BinaryNode<int>(23));
            binaryTreeStructure.Insert(new BinaryNode<int>(14));
            binaryTreeStructure.Insert(new BinaryNode<int>(31));
            binaryTreeStructure.Insert(new BinaryNode<int>(7));
            binaryTreeStructure.Insert(new BinaryNode<int>(17));
            binaryTreeStructure.Insert(new BinaryNode<int>(9));


            Console.WriteLine(binaryTreeStructure.FindNode(7));
            Console.ReadLine();
        }
    }
}
