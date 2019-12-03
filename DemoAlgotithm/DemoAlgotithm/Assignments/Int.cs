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
        public static int Factor3And5(int low, int high)
        {
            double valueOf3 = 0, valueOf5 = 0, totalValue = 0;
            int powerOf3 = 0, powerOf5 = 0, result = 0;

            while (valueOf3 <= high)
            {
                valueOf3 = Math.Pow(3, powerOf3);
                while (valueOf5 <= high)
                {
                    valueOf5 = Math.Pow(5, powerOf5);
                    totalValue = valueOf3 * valueOf5;
                    if (totalValue >= low && totalValue <= high)
                    {
                        result++;
                    }
                    powerOf5++;
                }

                valueOf5 = 0;
                powerOf5 = 0;
                powerOf3++;
            }

            return result;
        }

        /*
         https://app.codesignal.com/arcade/intro/level-7/vExYvcGnFsEYSt8nQ
             */
        int circleOfNumbers(int n, int firstNumber)
        {
            int temp = firstNumber + n / 2;
            if (temp >= n)
            {
                temp -= n;
            }
            return temp;
        }


        public static bool evenDigitsOnly(int n)
        {
            int temp = 0;
            while (n > 0)
            {
                temp = n % 10;
                if (temp % 2 != 0)
                {
                    return false;
                }
                n = n / 10;
            }

            return true;
        }


        public static int AddTwoDigits(int n)
        {
            return n/10 + n%10;
        }

        static int Reversal(int number)
        {
            if (number >= 10)
            {
                int ReverseNumber = 0;
                while (number > 0)
                {
                    ReverseNumber = (ReverseNumber * 10) + (number % 10);
                    number = number / 10;
                }
                return ReverseNumber;
            }

            return number;
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
