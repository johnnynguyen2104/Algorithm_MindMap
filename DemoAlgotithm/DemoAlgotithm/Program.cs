using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList_Algorithm.LinkedList<int> linkedList = new LinkedList_Algorithm.LinkedList<int>();
            linkedList.Add(new LinkedList_Algorithm.LinkedListNode<int>(1));
            linkedList.Add(new LinkedList_Algorithm.LinkedListNode<int>(2));
            linkedList.Add(new LinkedList_Algorithm.LinkedListNode<int>(3));
        }
    }
}
