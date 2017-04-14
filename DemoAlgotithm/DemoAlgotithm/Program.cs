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

            //Console.WriteLine(Assignments.Assignments.ReverseParentheses("ab(ac)aa"));
            Console.WriteLine(Assignments.Assignments.AreSimilar(new int[] { 2, 3, 1 }, new int[] { 1, 3, 2 } ));

            Console.ReadLine();
        }
    }
}
