using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAlgotithm.BinaryTree;

namespace DemoAlgotithm.Heap_DataStructure
{
    public class MinHeapBinary<T> : Comparer<T> where T :IComparable<T>
    {
        public int Count { get; }
        public BinaryNode<T> Root {
            get { return _root; }
        }

        private BinaryNode<T> _root; 

        public void Insert(T value)
        {
            if (Root == null)
            {
                _root = new BinaryNode<T>(value);
            }
            else
            {
                InsertNode(Root, value);
            }
        }

        private void RightRotation(BinaryNode<T> node)
        {
            /*
             LeftNode ← node.Left
            7) node.Left ← LeftNode.Right
            8) LeftNode.Right ← node
             */
        }

        private void LeftRotation(BinaryNode<T> node)
        {

        }

        private void InsertNode(BinaryNode<T> root, T value)
        {
            if (value != null)
            {
                if (root.Value.CompareTo(value) > 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = new BinaryNode<T>(value);
                    }
                    else
                    {
                        InsertNode(root.Left, value);
                    }
                    
                }
                else
                {
                    if (root.Right == null)
                    {
                        root.Right = new BinaryNode<T>(value);
                    }
                    else
                    {
                        InsertNode(root.Right, value);
                    }
                }

            }
        }

        public override int Compare(T x, T y)
        {
            if (x != null)
            {
                return y != null ? x.CompareTo(y) : 1;
            }

            if (y != null)
            {
                return -1;
            }

            return 0;
        }
    }
}
