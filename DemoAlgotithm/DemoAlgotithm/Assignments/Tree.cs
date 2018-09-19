using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public class Tree<T>
    {
        public T value { get; set; }
        public Tree<T> left { get; set; }
        public Tree<T> right { get; set; }
    }
    public static class TreeAssignment
    {
        public static bool isTreeSymmetric(Tree<int> t)
        {
            if (t == null)
            {
                return true;
            }

            bool result = true;

            if ((t.left == null && t.right != null) 
                || (t.left != null && t.right == null))
            {
                result = false;
            }
            else
            {
                result = isTreeSymmetric(t.left);
                if (result)
                {
                    result = isTreeSymmetric(t.right);
                }
            }
            

            return result;
        }

        public static bool hasPathWithGivenSum(Tree<int> t, int s)
        {
            return SumOfTreeVertex(t, 0, s);
        }

        private static bool SumOfTreeVertex(Tree<int> t, int currentVal, int comparedValue)
        {
            if (t == null)
            {
                return currentVal == comparedValue;
            }

            currentVal += t.value;
            if (t.right == null && t.left == null && currentVal == comparedValue)
            {
                return true;
            }
            bool result = false;
            if (t.right != null)
            {
                result = SumOfTreeVertex(t.right, currentVal, comparedValue);
            }

            if (t.left != null && !result)
            {
                result = SumOfTreeVertex(t.left, currentVal, comparedValue);
            }

            return result;
        }

    }
}
