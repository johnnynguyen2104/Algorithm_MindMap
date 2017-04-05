using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.LinkedList_Algorithm
{

    //LinkedList_Algorithm.LinkedList<int> linkedList = new LinkedList_Algorithm.LinkedList<int>();
    //linkedList.Insert(new LinkedList_Algorithm.LinkedListNode<int>(1));
    //linkedList.Insert(new LinkedList_Algorithm.LinkedListNode<int>(2));
    //linkedList.Insert(new LinkedList_Algorithm.LinkedListNode<int>(3));
    //linkedList.Delete(2);
    //Console.WriteLine(linkedList.Contains(4));

    public class LinkedListNode<T>
    {

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }
    }
    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; set; }

        public LinkedListNode<T> Tail { get; set; }

        public bool Delete(T value)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Value.Equals(value))
            {
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
            }
            else
            {
                var current = Head.Next;
                while (current != null && !current.Value.Equals(value))
                {
                    current = current.Next;
                }

                if (current == Tail)
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
                else if (current != null)
                {
                    current = current.Next;
                    current.Previous = current.Previous.Previous;
                    current.Previous.Next = current;
                }


                return false;
            }

            return false;
        }

        public bool Contains(T value)
        {
            if (value == null) return false;

            var current = Head;

            while (current != null && !current.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }
            return true;
        }

        public void Insert(LinkedListNode<T> value)
        {
            if (value == null) return;

            var node = value;
            if (Head == null)
            {
                //make Head and tail point to one memory
                Head = value;
                Tail = value;
            }
            else
            {
                node.Previous = Tail;
                //changing this the head will be changed  
                Tail.Next = value;
                Tail = value;
            }
        }
    }
}
