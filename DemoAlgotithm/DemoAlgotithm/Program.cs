using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoAlgotithm.Assignments;
using DemoAlgotithm.BinaryTree;

namespace DemoAlgotithm
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(TreeAssignment.hasPathWithGivenSum(new Tree<int>() {
            //    left = new Tree<int>() { value = 1, left = new Tree<int>() { value = -2, right = new Tree<int>() { value = 3 } } },
            //    right = new Tree<int>() { value = 3, left = new Tree<int>() { value = 1 }, right = new Tree<int>() { value = 2, left = new Tree<int>() { value = -2 }, right = new Tree<int>() { value = -3 } } },
            //    value = 4

            //}, 7));
            int[,] matrix = new int[,]{{5, 5, -1, 2 },
 { 5, -1, 20, 15},
 {5, 20, -2, 13},
 {5, 10, 10, 30}};
            var a = Assignments.Assignments.maximumNonAdjacentCellsSum(matrix);
            Console.ReadLine();
        }
    }
}
