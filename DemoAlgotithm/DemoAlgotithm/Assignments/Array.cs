using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        public static int MaxDoubleSliceSum(int[] A)
        {
            //https://en.wikipedia.org/wiki/Maximum_subarray_problem
            if (A.Length == 3)
            {
                return 0;
            }

            int n = A.Length;
            int[] max_sum_end = new int[A.Length];
            int[] max_sum_start = new int[A.Length];

            /*
             # A[X + 1] + A[X + 2] + ... + A[Y − 1]
            # Let's assume that Y is equal to i+1.
            # If l_max_slice_sum[i-1] + A[i] is negative, we assign X to i.
            # It means that the slice sum is 0 because X and Y are consecutive indices.
             */
            for (int i = 1; i < (n - 1); i++)
            {
                max_sum_end[i] = System.Math.Max(0, max_sum_end[i - 1] + A[i]);
            }

            /*
              # We suppose that Y is equal to i-1.
                # As aforementioned, Z will be assigned to i if r_max_slice_sum[i+1] + A[i]
                # is negative, and it returns 0 because Y and Z becomes consecutive indices.
             */
            for (int i = n - 2; i > 0; i--) // i=0 and i=n-1 are not used because x=0,z=n-1
            {
                max_sum_start[i] = System.Math.Max(0, max_sum_start[i + 1] + A[i]);
            }

            int maxvalue = 0;

            /*
             # Let's say that i is the index of Y.
            # l_max_slice_sum[i-1] is the max sum of the left slice, and
            # r_max_slice_sum[i+1] is the max sum of the right slice.
             */
            for (int i = 1; i < (n - 1); i++)
            {
                maxvalue = System.Math.Max(maxvalue, max_sum_end[i - 1] + max_sum_start[i + 1]);
            }

            return maxvalue;
        }

        public static int MaxSliceSum(int[] A)
        {
            //https://en.wikipedia.org/wiki/Maximum_subarray_problem
            //Kadane's Algo

            //int maxSum = A[0], subSum = A[0];
            //for (int i = 1; i < A.Length; i++)
            //{
            //    subSum = Math.Max(subSum + A[i], A[i]);
            //    maxSum = Math.Max(maxSum, subSum);
            //}

            //return maxSum;

            /*
             It uses two variables: ‘max’ to represent maximum sum and ‘acc’ for storing cumulative sum. If acc is negative at the current step, it restarts cumulative sum by assigning 0; that is because the next sum would be negatively affected.
             */
            int subSum = 0, max = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                subSum += A[i];
                max = Math.Max(max, subSum);

                if (subSum < 0)
                {
                    subSum = 0;
                }
            }

            return max;
        }

        public static int MaxProfit(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 0)
            {
                return 0;
            }

            int max = -1, min = 200001, P = 0, Q = 0, profit = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (max < A[i])
                {
                    max = A[i];
                    Q = i;
                }

                if (min > A[i])
                {
                    min = A[i];
                    P = i;

                    if (P > Q)
                    {
                        max = A[i];
                        Q = P;
                    }
                }

                profit = Math.Max(profit, A[Q] - A[P]);
            }

            return profit;
        }

        public static int Distinct(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            HashSet<int> hs = new HashSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (!hs.Contains(A[i]))
                {
                    hs.Add(A[i]);
                }
            }

            return hs.Count;
        }

        public static int MaxProductOfThree(int[] A)
        {
            int min1 = 1001, min2 = 1001,
                max1 = -1001, max2 = -1001, max3 = -1001;

            for (int i = 0; i < A.Length; i++)
            {
                if (min1 > A[i])
                {
                    min2 = min1;
                    min1 = A[i];
                }
                else if (min2 > A[i])
                {
                    min2 = A[i];
                }

                if (max1 < A[i])
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = A[i];
                }
                else if (max2 < A[i])
                {
                    max3 = max2;
                    max2 = A[i];
                }
                else if (max3 < A[i])
                {
                    max3 = A[i];
                }
            }

            return System.Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }

        public static int MinAvgTwoSlice(int[] A)
        {
            int minAvgIdx = 0;
            double minAvgVal = (A[0] + A[1]) / 2; //At least two elements in A.
            double currAvg;
            for (int i = 0; i < A.Length - 2; i++)
            {
                /**
                 * We check first the two-element slice
                 */
                currAvg = ((double)(A[i] + A[i + 1])) / 2;
                if (currAvg < minAvgVal)
                {
                    minAvgVal = currAvg;
                    minAvgIdx = i;
                }
                /**
                 * We check the three-element slice
                 */
                currAvg = ((double)(A[i] + A[i + 1] + A[i + 2])) / 3;
                if (currAvg < minAvgVal)
                {
                    minAvgVal = currAvg;
                    minAvgIdx = i;
                }
            }
            /**
             * Now we have to check the remaining two elements of the array
             * Inside the for we checked ALL the three-element slices (the last one
             * began at A.length-3) and all but one two-element slice (the missing
             * one begins at A.length-2).
             */
            currAvg = ((double)(A[A.Length - 2] + A[A.Length - 1])) / 2;
            if (currAvg < minAvgVal)
            {
                minAvgVal = currAvg;
                minAvgIdx = A.Length - 2;
            }

            return minAvgIdx;
        }
        public static int[] MaxCounters(int N, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int max = 0, maxCounter = 0;
            int[] result = new int[N];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == N + 1)
                {
                    maxCounter = max;
                }
                else
                {
                    if (result[A[i] - 1] < maxCounter)
                    {
                        //plus with maxCounter and +1 because need to increase it as it appear again.
                        result[A[i] - 1] = maxCounter + 1;
                    }
                    else
                    {
                        result[A[i] - 1]++;
                    }


                    if (max < result[A[i] - 1])
                    {
                        max = result[A[i] - 1];
                    }
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < maxCounter)
                {
                    result[i] = maxCounter;
                }
            }
            return result;
        }

        public static int FrogRiverOne(int X, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int steps = X;
            bool[] bitmap = new bool[steps + 1];

            for (int i = 0; i < A.Length; i++)
            {
                if (!bitmap[A[i]])
                {
                    bitmap[A[i]] = true;
                    steps--;
                }
                if (steps == 0) return i;
            }
            return -1;
        }

        public static int PassingCars(int[] A)
        {
            int east = 0, west = 0, count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    east++;
                }
                else
                {
                    west++;
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    count += west;
                    if (count >= 1000000000)
                    {
                        return -1;
                    }
                    east--;
                }
                else
                {
                    west--;
                }
            }
            return count;
        }

        public static int MissingInteger(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            HashSet<int> existValue = new HashSet<int>();
            int max = int.MinValue;
            int result = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (!existValue.Contains(A[i]))
                {
                    existValue.Add(A[i]);
                }

                if (A[i] > max) max = A[i];
            }

            for (int i = 1; i <= max; i++)
            {
                if (!existValue.Contains(i))
                {
                    result = i;
                    break;
                }
            }

            if (result == 0)
            {
                if (max + 1 <= 0)
                {
                    return 1;
                }
                return max + 1;
            }

            return result;
        }

        public static int PermCheck(int[] A)
        {
            HashSet<int> existValue = new HashSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (existValue.Contains(A[i]))
                {
                    return 0;
                }
                existValue.Add(A[i]);
            }

            for (int i = 1; i <= A.Length; i++)
            {
                if (!existValue.Contains(i))
                {
                    return 0;
                }
            }

            return 1;
        }

        public static int PermMissingElem(int[] A)
        {
            int[] a = new int[A.Length + 2];
            int result = -1;

            for (int i = 0; i < A.Length; i++)
            {
                a[A[i]]++;
            }

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        static long CoinChangeWays(int n, int[] coins)
        {
            Dictionary<string, long> memorization = new Dictionary<string, long>();

            return solution(n, coins, 0, memorization);
        }

        static long solution(int money, int[] coins, int startPoint, Dictionary<string, long> memorization)
        {
            long ways = 0;

            if (money == 0)
            {
                return 1;
            }

            if (money < 0)
            {
                return 0;
            }

            string key = $"{money}-{startPoint}";
            if (memorization.ContainsKey(key))
            {
                return memorization[key];
            }
           
            for (int i = startPoint; i < coins.Length; i++)
            {
                ways += solution(money - coins[i], coins, i, memorization);
            }

            memorization.Add(key, ways);

            return ways;
        }

        static int MinimumSwaps(List<int> popularity)
        {
            int result = 0, tempData = 0, tempIndex = 0, tempData2;
            Dictionary<int, int> reflectionIndexOfTheArray = new Dictionary<int, int>();

            //Build up a reflection of the Index of array
            //to avoid loop the array many times
            //With this dictionary, I can reduce the complexity of my code from O(N^2) -> O(N)
            for (int i = 0; i < popularity.Count; i++)
            {
                reflectionIndexOfTheArray.Add(popularity[i], i);
            }

            for (int i = 0; i < popularity.Count; i++)
            {
                tempData = popularity[i];

                if (popularity[i] != popularity.Count - i)
                {
                    tempIndex = reflectionIndexOfTheArray[popularity.Count - i];

                    //Swaping between two values
                    popularity[i] = popularity[tempIndex];
                    popularity[tempIndex] = tempData;

                    //Updating new Index for the reflection.
                    tempData2 = reflectionIndexOfTheArray[popularity.Count - i];
                    reflectionIndexOfTheArray[popularity.Count - i] = i;
                    reflectionIndexOfTheArray[tempData] = tempData2;

                    result++;
                }
            }

            return result;
        }

        static int MinimumSwaps2(int[] arr)
        {
            int result = 0, temp = 0;

            Dictionary<int, int> tempDic = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                tempDic.Add(arr[i], i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];

                if (arr[i] != i + 1)
                {
                    arr[i] = arr[tempDic[arr.Length - i]];
                    arr[tempDic[arr.Length - i]] = temp;

                    tempDic[temp] = tempDic[arr.Length - i];
                    tempDic[arr.Length - i] = i;
                    result++;
                }
            }

            return result;
        }

        public static int[] ConstructArray(int size)
        {
            int[] result = new int[size];
            int digitIndex = 1, sizeIndex = 0;
            for (int i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = digitIndex;
                    digitIndex++;
                }
                else
                {
                    result[i] = size - sizeIndex;
                    sizeIndex++;
                }
                
            }

            return result;
        }

        public static int[] ArrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == elemToReplace)
                {
                    inputArray[i] = substitutionElem;
                }
            }

            return inputArray;
        }

        public static void MiniMaxSum(int[] arr)
        {
            Int64 total = 0, max = 0, min = Int64.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];

                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine(string.Format("{0} {1}", (total - max), (total - min)));
        }


        #region
        /*
         * Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in one of the arrays.

            Given two arrays, check whether they are similar.

            Example

            For A = [1, 2, 3] and B = [1, 2, 3], the output should be
            areSimilar(A, B) = true.

            The arrays are equal, no need to swap any elements.

            For A = [1, 2, 3] and B = [2, 1, 3], the output should be
            areSimilar(A, B) = true.

            We can obtain B from A by swapping 2 and 1 in B.

            For A = [1, 2, 2] and B = [2, 1, 1], the output should be
            areSimilar(A, B) = false.

            Any swap of any two elements either in A or in B won't make A and B equal.
         */
        #endregion
        public static bool AreSimilar(int[] A, int[] B)
        {

            for (int i = 1; i < A.Length - 1; i++)
            {

                if ((A[i - 1] != B[i - 1] || A[i] != B[i] || A[i + 1] != B[i + 1])
                    && (A[i - 1] != B[i + 1] && A[i] != B[i] && A[i + 1] != B[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }



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

        static int SimpleArraySum(int n, int[] ar)
        {
            int result = 0;
            if (n > 0 && ar.Length > 0)
            {

                for (int i = 0; i < n; i++)
                {
                    result += ar[i];
                }
            }

            return result;
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
