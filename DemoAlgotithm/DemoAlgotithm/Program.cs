using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAlgotithm.Assignments;
using DemoAlgotithm.BinaryTree;

namespace DemoAlgotithm
{
    class Program
    {
        



        static void Main(string[] args)
        {
           
        }

        #region
        static int solution(int n, int m)
        {
            int sumOfDivisible = 0, sumOfNotDivisible = 0;
            for (int i = 1; i <= m; i++)
            {
                if (i % n == 0)
                {
                    sumOfDivisible += i;
                }
                else
                {
                    sumOfNotDivisible += i;
                }
            }

            return sumOfNotDivisible - sumOfDivisible;
        }

        static int fibo(int n)
        {
            int result = 0;

            if (n == 1 || n == 2)
            {
                result = 1;
            }
            else
            {
                result = fibo(n - 1) + fibo(n - 2);
            }
            return result;
        }
       

        // Complete the lonelyinteger function below.
        //static int maximizingXor(int l, int r)
        //{
        //    int max = 0;
        //    int xorTempResult = 0;

        //    for (int i = l; i < r; i++)
        //    {
        //        xorTempResult = i 
        //    }

        //}

        static void shiftByK(char[] S, char[] shiftedS, int N, int K)
        {
            // Iterate through the length of given string
            for (int i = 0; i < N; i++)
            {
                // Find the index for this current character in shiftedS[]
                int idx = (i + K) % N;
                // Copy that character at the found index idx
                shiftedS[idx] = S[i];
            }
            // Add a NULL character to mark the end of string
            shiftedS[N] = '\0';
        }

        static int camelcase(string s)
        {
            if (s == null || s == "")
            {
                return 0;
            }

            int result = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 65 && s[i] <= 90)
                {
                    result++;
                }
            }
            return result;
        }


        static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong

            int oneDigit = 1, lower = 1, upper = 1, sc = 1;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    oneDigit = 0;
                }
                else if (char.IsLower(password[i]))
                {
                    lower = 0;
                }
                else if (char.IsUpper(password[i]))
                {
                    upper = 0;
                }
                else if (password[i] >= 33 && password[i] <= 45)
                {
                    sc = 0;
                }
            }

            int sumRules = oneDigit + lower + upper + sc;
            if (sumRules + password.Length > 6)
            {
                return sumRules;
            }

            return 6 - password.Length;
        }

        static void Permutation(char c, string s, int index, HashSet<string> result)
        {
            if (index < s.Length)
            {
                result = result ?? new HashSet<string>();
                string temp = $"{c}{s[index]}";
                if (c != s[index] && !result.Contains(temp) && !result.Contains($"{s[index]}{c}"))
                {
                    result.Add(temp);
                }

                Permutation(c, s, ++index, result);
            }
        }
        static int alternate(string s)
        {

            HashSet<char> hs = new HashSet<char>();
            //O(N)
            for (int i = 0; i < s.Length; i++)
            {
                if (!hs.Contains(s[i]))
                {
                    hs.Add(s[i]);
                }
            }

            var uniqueChar = hs.ToArray();
            List<string> comparationPairs = new List<string>();
            //O(N2)
            for (int i = 0; i < uniqueChar.Length; i++)
            {
                for (int j = i + 1; j < uniqueChar.Length; j++)
                {
                    comparationPairs.Add(string.Concat(uniqueChar[i], uniqueChar[j]));
                }
            }

            string tempBuilder = string.Empty;
            char previousChar = new char();
            int maxValidString = 0;
            //o(N2)
            for (int i = 0; i < comparationPairs.Count; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if ((s[j] == comparationPairs[i][0] || s[j] == comparationPairs[i][1]))
                    {
                        if (previousChar == s[j])
                        {
                            tempBuilder = string.Empty;
                            break;
                        }
                        tempBuilder += s[j];
                        previousChar = s[j];
                    }
                }

                if (tempBuilder.Length > 0 && tempBuilder.Length > maxValidString)
                {
                    maxValidString = tempBuilder.Length;
                }

                tempBuilder = string.Empty;
                previousChar = new char();

            }

            return maxValidString;
        }

        // Complete the caesarCipher function below.
        static string caesarCipher(string s, int k)
        {
            int temp = -1;
            char[] result = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                temp = s[i];

                if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    temp = ((temp - 'A' + k) % 26) + 'A';
                }
                else if (s[i] >= 'a' && s[i] <= 'z')
                {
                    temp = ((temp - 'a' + k) % 26) + 'a';
                }

                result[i] = (char)temp;
            }

            return string.Concat(result);
        }

        static int marsExploration(string s)
        {
            string pattern = "SOS";
            int missMatchResult = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != pattern[i % 3])
                {
                    missMatchResult++;
                }
            }

            return missMatchResult;
        }


        static string hackerrankInString(string s)
        {
            string result = string.Empty;
            string fixedString = "hackerrank";
            int j = 0;

            if (s.Length < fixedString.Length)
            {
                return "NO";
            }

            for (int i = 0; i < s.Length; i++)
            {
                //j < fixedString.Length &&
                if (j < fixedString.Length && s[i] == fixedString[j]) {
                    j++;
                }
            }

            if (j == fixedString.Length)
            {
                result = "YES";
            }
            else {
                result = "NO";
            }

            return result;
        }

        static string pangrams(string s)
        {
            int[] alphabetArray = new int[123];
            char tempChar = ' ';

            for (int i = 0; i < s.Length; i++)
            {
                tempChar = s[i];
                if (tempChar >= 'A' && tempChar <= 'Z')
                {
                    tempChar = (char)(tempChar + 32);
                }

                alphabetArray[tempChar]++;
            }

            for (int i = 'a'; i < 'z'; i++)
            {
                if (alphabetArray[i] == 0)
                {
                    return "not pangram";
                }
            }
            return "pangram";
        }

        // Complete the weightedUniformStrings function below.
        static string[] weightedUniformStrings(string s, int[] queries)
        {
            HashSet<int> t = new HashSet<int>();
            int uniformStringSum = 0;
            char previous = ' ';

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != previous)
                {
                    t.Add(s[i] - 'a');
                    previous = s[i];
                    uniformStringSum = s[i] - 'a';
                }
                else
                {
                    uniformStringSum += s[i] - 'a';
                    t.Add(uniformStringSum);
                }
            }

            List<string> result = new List<string>(queries.Length);

            for (int i = 0; i < queries.Length; i++)
            {
                if (t.Contains(queries[i]))
                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("No");
                }
            }

            return result.ToArray();
        }

        // Complete the separateNumbers function below.
        static void separateNumbers(string s)
        {
            if (s.Length == 1)
            {
                Console.WriteLine("NO");
            }

            List<string> ar = new List<string>();
            int previous = s[0];
            string subS = string.Concat(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] - previous == 1 && s[i] != 0)
                {
                    ar.Add(subS);
                    subS = string.Concat(s[i]);
                }
                else
                {
                    subS += s[i];
                }
                previous = s[i];
            }
        }

        static int CalculateRefillingWaterTimes(int[] plants, int cabicity1, int cabicity2)
        {
            int totalRefillingTimes = 0;
            int tempCabicity1 = cabicity1; // tempcabicity1/2 to user for calculating cabicity after watering
            int tempCabicity2 = cabicity2;
            int plantLength = 0;
            // this condition helping us build condition to let the loop stop in the right time
            if (plants.Length % 2 == 0)
            {
                plantLength = plants.Length/2;
            }
            else {
                plantLength = (plants.Length + 1) / 2;
            }
            // this variable to let my friend can start from the last plant
            int mf = plants.Length - 1;
            for (int m = 0; m < plantLength; m++)
            {
                if (tempCabicity1 < plants[m])
                {
                    totalRefillingTimes++;
                    tempCabicity1 = cabicity1;
                }
                if (tempCabicity2 < plants[mf]) {
                    totalRefillingTimes++;
                    tempCabicity2 = cabicity2;
                }
                tempCabicity1 = tempCabicity1 - plants[m];
                tempCabicity2 = tempCabicity2 - plants[mf];
                mf--;
            }
            return totalRefillingTimes;
        }


        static void minimumBribes(int[] q)
        {
            int bridesTime = 0;
            if (q.Length <= 1)
            {
                Console.WriteLine(bridesTime);
            }

            int temp = 0;
            int previous = q[0];
            for (int i = 0; i < q.Length; i++)
            {
                temp = Math.Abs(q[i] - (i + 1));
                if (q[i] >= previous)
                {
                    if (temp > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                    else if (temp > 0)
                    {
                        bridesTime+=temp;
                        previous = q[i];
                    }
                }
               
            }

            Console.WriteLine(bridesTime);
        }
        #endregion
    }
}
