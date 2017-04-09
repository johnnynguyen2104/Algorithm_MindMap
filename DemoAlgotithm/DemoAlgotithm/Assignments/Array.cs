using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {

        #region
        /*
         Several people are standing in a row and need to be divided into two teams. 
         The first person goes into team 1, the second goes into team 2, the third goes into team 1 again, 
         the fourth into team 2, and so on.

        You are given an array of positive integers - the weights of the people. Return an array of two integers, where the first element is the total weight of team 1, and the second element is the total weight of team 2 after the division is complete.

        Example

        For a = [50, 60, 60, 45, 70], the output should be
        alternatingSums(a) = [180, 105].
             */
        #endregion
        public static int[] AlternatingSums(int[] a)
        {
            int teamA = 0, teamB = 0;

            for (int i = 0; i < a.Length; i += 2)
            {
                teamA += i >= a.Length ? 0 : a[i];
                teamB += (i + 1) >= a.Length ? 0 : a[i + 1];
            }

            return new int[] { teamA, teamB };
        }



        #region
        /*Some people are standing in a row in a park. 
         * There are trees between them which cannot be moved. 
         * Your task is to rearrange the people by their heights in a non-descending order without moving the trees.
         */
        #endregion

        public static int[] SortByHeight(int[] a)
        {
            int temp = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[j] != -1 && a[i] > a[j])
                        {
                            temp = a[i];
                            a[i] = a[j];
                            a[j] = temp;
                        }
                    }
                }
            }

            return a;
        }

        #region
        //Given an array of strings, return another array containing all of its longest strings
        #endregion
        public static string[] AllLongestStrings(string[] inputArray)
        {

            string[] result = new string[0];
            int longest = 0, index = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (longest < inputArray[i].Length)
                { 
                    //clear all the array string result because we have new longest string.
                    result = new string[0];
                    index = 0;
                    longest = inputArray[i].Length;
                    //

                    index++;
                    result = AddStringItem(inputArray, result, index, i);
                }
                else if(longest == inputArray[i].Length)
                {
                    index++;
                    result = AddStringItem(inputArray, result, index, i);
                }
            }

            return result;
        }

        private static string[] AddStringItem(string[] inputArray, string[] result, int index, int i)
        {
            Array.Resize(ref result, index);
            result[index - 1] = inputArray[i];
            return result;
        }

        #region
        /*
         * Given a sequence of integers as an array, determine whether it is possible to obtain a strictly increasing sequence by removing no more than one element from the array.

        Example

        For sequence = [1, 3, 2, 1], the output should be
        almostIncreasingSequence(sequence) = false;

        There is no one element in this array that can be removed in order to get a strictly increasing sequence.

        For sequence = [1, 3, 2], the output should be
        almostIncreasingSequence(sequence) = true.

        You can remove 3 from the array to get the strictly increasing sequence [1, 2]. Alternately, you can remove 2 to get the strictly increasing sequence [1, 3].
         */
        #endregion
        public static bool AlmostIncreasingSequence(int[] sequence)
        {
            int[] temp = new int[sequence.Length - 1];
            temp[0] = sequence[0];
            int index = 0;

            for (int i = 1; i < sequence.Length; i++)
            {
                if ((temp[index]) >= sequence[i])
                {
                    if (index - 1 >= 0 && sequence[i] > temp[index - 1])
                    {
                        temp[index] = sequence[i];
                    }
                    else if(index - 1 < 0)
                    {
                        temp[index] = sequence[i];
                    }
                    
                }
                else
                {
                    index++;
                    temp[index] = sequence[i];
                }
            }

            if (index == sequence.Length - 2)
            {
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    if (temp[i] + 1 > temp[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        #region
        //Ratiorg got statues of different sizes as a present from CodeMaster for his birthday, each statue having an non-negative integer size.Since he likes to make things perfect, he wants to arrange them from smallest to largest so that each statue will be bigger than the previous one exactly by 1. He may need some additional statues to be able to accomplish that.Help him figure out the minimum number of additional statues needed.

        //Example

        //For statues = [6, 2, 3, 8], the output should be
        //makeArrayConsecutive2(statues) = 3.

        //Ratiorg needs statues of sizes 4, 5 and 7.

        //Input/Output

        //[time limit] 6000ms(cs)
        //[input]
        //        array.integer statues

        //An array of distinct non-negative integers.

        //Guaranteed constraints:
        //1 ≤ statues.length ≤ 10,
        //0 ≤ statues[i] ≤ 20.

        //[output] integer

        //The minimal number of statues that need to be added to existing statues such that it contains every integer size from an interval [L, R] (for some L, R) and no other sizes.
        #endregion
        public static int MakeArrayConsecutive2(int[] statues)
        {
            if (statues.Length < 2) return 0;

            Array.Sort(statues);

            int vResult =0;

            for (int i = 0; i < statues.Length - 1; i++)
            {
                vResult += statues[i + 1] - statues[i] - 1;
            }

            return vResult;
        }

        public static int AdjacentElementsProduct(int[] inputArray)
        {
            if (inputArray.Length == 2)
            {
                return inputArray[0] * inputArray[1];
            }

            var length = inputArray.Length;
            int result = int.MinValue;

            for (int i = 0; i < length - 1; i += 1)
            {
                int val = inputArray[i] * inputArray[i + 1];
                if (result < val)
                {
                    result = val;
                }
            }

            return result;
        }

    }
}
