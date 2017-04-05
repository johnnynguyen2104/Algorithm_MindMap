using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        public static int AddTwoDigits(int n)
        {
            return n/10 + n%10;
        }

        //Given an integer n, return the largest number that contains exactly n digits.
        public static int LargestNumber(int n)
        {
            return (10*n)*9;
        }
    }
}
