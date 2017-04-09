using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        #region
        /*
         Ticket numbers usually consist of an even number of digits. 
         A ticket number is considered lucky if the sum of the first half of the digits is equal to the sum of the second half.
            Given a ticket number n, determine if it's lucky or not.
             */
        #endregion
        public static bool IsLucky(int n)
        {
            int[] array = new int[0];
            int currentVal = 10, index = 0;
            while ((n / currentVal) >= 0 && n != 0)
            {
                index++;
                Array.Resize(ref array, index);
                array[index - 1] = (n % currentVal);
                n = (n / currentVal);
            }

            int sumOfValue = 0, left = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumOfValue += array[i];
            }

            for (int i = 0; i < array.Length / 2; i++)
            {
                left += array[i];
                sumOfValue -= array[i];
                if (left == sumOfValue)
                {
                    return true;
                }
            }

            return false;
        }


        //Given an integer n, return the largest number that contains exactly n digits.
        //public static int LargestNumber(int n)
        //{
        //    return n /;
        //}
    }
}
