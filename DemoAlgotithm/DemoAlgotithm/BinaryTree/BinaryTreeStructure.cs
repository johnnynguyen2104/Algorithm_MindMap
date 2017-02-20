﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.BinaryTree
{
    public class BinaryNode<T>
    {
        public BinaryNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public BinaryNode<T> Left { get; set; }

        public BinaryNode<T> Right { get; set; }
    }

    public class BinaryTreeStructure<T> : Comparer<T> where T :IComparable<T>
    {
        private BinaryNode<T> _root;

        private long _count;

        public BinaryNode<T> Root => _root;

        public long Count => _count;

        public bool Search(T value, BinaryNode<T> root = null)
        {

            if (value != null)
            {
                if (root != null)
                {
                    return Contains(root, value);
                }

                return Contains(Root, value);
            }

            return false;
        }

        public BinaryNode<T> FindParentNode(T value, BinaryNode<T> root = null)
        {
            if (value != null)
            {
                if (root != null)
                {
                    return FindParent(root, value);
                }

                return FindParent(Root, value);
            }

            return null;
        } 

        public bool Delete(T value)
        {
            if (value != null)
            {
                if (Root == null)
                {
                    return false;
                }


               
            }

            return false;
        }

        public void Insert(BinaryNode<T> value)
        {
            if (value == null) return;

            if (Root == null)
            {
                _root = value;
            }
            else
            {
                InsertNode(Root, value.Value);
            }
            _count++;
        }

        public BinaryNode<T> FindNode(T value, BinaryNode<T> root = null)
        {
            if (value != null)
            {
                if (root != null)
                {
                    return Find(root, value);
                }

                return Find(Root, value);
            }
            return null;
        } 

        private bool Contains(BinaryNode<T> root , T value)
        {
            if (value == null || root == null)
            {
                return false;
            }

            if (root.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else if(root.Value.CompareTo(value) > 0)
            {
                return Contains(root.Left, value);
            }
            else
            {
                return Contains(root.Right, value);
            }
        }

        private BinaryNode<T> Find(BinaryNode<T> root, T value)
        {
            if (value == null || root == null)
            {
                return null;
            }

            if (root.Value.CompareTo(value) == 0)
            {
                return root;
            }
            else if (root.Value.CompareTo(value) > 0)
            {
                return Find(root.Left, value);
            }
            else
            {
                return Find(root.Right, value);
            }
        } 

        private void InsertNode(BinaryNode<T> current, T value)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new BinaryNode<T>(value);
                }
                else
                {
                    InsertNode(current.Left, value);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new BinaryNode<T>(value);
                }
                else
                {
                    InsertNode(current.Right, value);
                }
            }
        }

        private BinaryNode<T> FindParent(BinaryNode<T> startNode, T value)
        {
            if (value != null && startNode != null)
            {
                if (startNode.Value.CompareTo(value) == 0)
                {
                    return null;
                }
                else if(startNode.Value.CompareTo(value) > 0)
                {
                    if (startNode.Left == null)
                    {
                        return null;
                    }
                    else if (startNode.Left.Value.CompareTo(value) == 0)
                    {
                        return startNode;
                    }
                    else
                    {
                        return FindParent(startNode.Left, value);
                    }
                }
                else
                {
                    if (startNode.Right == null)
                    {
                        return null;
                    }
                    else if (startNode.Right.Value.CompareTo(value) == 0)
                    {
                        return startNode;
                    }
                    else
                    {
                        return FindParent(startNode.Right, value);
                    }
                }
            }

            return null;
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