using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        /*
         given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

        { i : A ≤ i ≤ B, i mod K = 0 }

        For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.
             */
        public static int CountDiv(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A % K == 0)
                return (B / K) - (A / K) + 1;

            // A is not divisible by M 
            return (B / K) - (A / K);
        }

        public static int BinaryGap(int N)
        {
            int count = -1, number = 0, max = 0;

            while (N >= 1)
            {
                number = (N % 2);
                if (number == 1 && count == -1)
                {
                    count = 0;
                }
                else if (number == 1 && count != -1)
                {
                    max = count > max ? count : max;
                    count = 0;
                }
                else if (number == 0 && count != -1)
                {
                    count++;
                }

                N = N / 2;
            }

            return max;
        }
        /*
         https://app.codesignal.com/arcade/intro/level-7/8PxjMSncp9ApA4DAb
             */
        public static int depositProfit(int deposit, int rate, int threshold)
        {
            int yearResult = 0;
            float increase = deposit;

            while (increase < threshold)
            {
                increase += (increase * ((float)rate / 100));
                yearResult++;
            }

            return yearResult;
        }


        //int[] rockPaperScissor(string opponentsMoves)
        //{

        //}
        /*
         For area = [[" ","S"," ","O"], ["G","S"," "," "], ["O","O"," "," "]] and direction = "S"
         , the output should be "ULL".
             */
        //static string iceCave(string[][] area, string direction)
        //{

        //}

        //private bool Is

        private int TurnLeft(int col)
        {
            return col++;
        }

        private int TurnRight(int col)
        {
            return col--;
        }

        private int GoUp(int row)
        {
            return row--;
        }

        private int GoDown(int row)
        {
            return row++;
        }


        public static void FizzBuzz(int endpoint)
        {
            StringBuilder builder = new StringBuilder(8);
            for (int i = 0; i < endpoint; i++)
            {
                builder.Append(i % 3 == 0 ? "Fizz" : "");
                builder.Append(i % 5 == 0 ? "Buzz" : "");
                builder.Append(builder.Length == 0 ? i.ToString() : "");
            }
        }

        /// <summary>
        /// Find the winner Johnny Or Carrie from a game
        /// </summary>
        /// <param name="a0">Johnny point 1</param>
        /// <param name="a1">Johnny point 2</param>
        /// <param name="a2">Johnny point 3</param>
        /// <param name="b0">Carrie point 1</param>
        /// <param name="b1">Carrie point 1</param>
        /// <param name="b2">Carrie point 1</param>
        /// <returns></returns>
        static int[] Solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {

            int[] a = new int[2] { 0, 0 };
            if (a0 != b0)
            {
                a[a0 > b0 ? 0 : 1]++;
            }

            if (a1 != b1)
            {
                a[a1 > b1 ? 0 : 1]++;
            }

            if (a2 != b2)
            {
                a[a2 > b2 ? 0 : 1]++;
            }

            return a;
        }

        static void PlusMinus(int[] arr)
        {
            if (arr.Length > 0)
            {
                int[] a = new int[3] { 0, 0, 0 };
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 0)
                    {
                        a[2]++;
                    }
                    else
                    {
                        a[arr[i] > 0 ? 0 : 1]++;
                    }

                }
                Console.WriteLine(((float)a[0] / arr.Length));
                Console.WriteLine(((float)a[1] / arr.Length));
                Console.WriteLine(((float)a[2] / arr.Length));
            }
        }

        static int BirthdayCakeCandles(int n, int[] ar)
        {
            if (n > 0 && ar.Length > 0)
            {
                int tallest = int.MinValue;
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (ar[i] > tallest)
                    {
                        count = 1;
                        tallest = ar[i];
                    }
                    else if (ar[i] == tallest)
                    {
                        count++;
                    }
                }
                return count;
            }
            return 0;
        }

        /// <summary>
        /// The defination of beautyful day is current day in the range - reversal current day / k
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static async Task<int> beautifulDaysAsync(int i, int j, int k)
        {
            if (i <= j && k != 0)
            {

                int result = 0;
                for (int f = i; f <= j; f++)
                {
                    result += await CalculateBDay(k, f);
                }
                return result;
            }

            return 0;
        }

        private async static Task<int> CalculateBDay(int k, int f)
        {
            float temp = (float)(f - Reversal(f)) / k;
            if (temp % 1 == 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Get Most visited on list of sprints
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sprints"></param>
        /// <returns></returns>
        static int GetMostVisited(int n, int[] sprints)
        {
            int[] result = new int[n + 1];

            int dep
                , arr;
            for (int i = 0; i < sprints.Length - 1; i++)
            {
                dep = sprints[i] > sprints[i + 1] ? sprints[i + 1] : sprints[i];
                arr = sprints[i] > sprints[i + 1] ? sprints[i] : sprints[i + 1];

                for (int j = dep; j <= arr; j++)
                {
                    result[j]++;
                }

            }

            int maxIndex = -1, maxValue = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (maxValue < result[i])
                {
                    maxIndex = i;
                    maxValue = result[i];
                }
            }

            return maxIndex;
        }
    }
}
