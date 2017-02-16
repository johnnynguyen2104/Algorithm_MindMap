using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.LinkedList_Algorithm
{
    public class LinkedListNode<T>
    {

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        
    }
    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; set; }

        public LinkedListNode<T> Tail { get; set; }

        public void Add(LinkedListNode<T> value)
        {
            if (value != null)
            {
                if (Head == null)
                {
                    Head = value;
                    Tail = value;
                }
                else
                {
                    Tail.Next = value;
                    Tail = value;
                }
            }
        }
    }
}
