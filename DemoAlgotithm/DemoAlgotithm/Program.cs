using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAlgotithm
{
    class Program
    {

        //public static int minimumSwaps(List<int> popularity)
        //{
        //    int result = 0;
        //    result = solution(popularity, popularity.Count - 1);
        //    return result;
        //}
        //public static int solution(List<int> popularity, int index)
        //{
        //    int totalWays = 0, expectedValue = popularity.Count - index, previousValue = 0;
        //    Dictionary<int, int> dic = new Dictionary<int, int>();
        //    if (index >= 0) {
        //        if (popularity[index] != expectedValue) {
        //            totalWays++;
        //            previousValue = popularity[index];
        //            for (int i = index; i >= 0; i--)
        //            {
        //                if (popularity[i] == expectedValue) {
        //                    popularity[index] = expectedValue;
        //                    popularity[i] = previousValue;
        //                    break;
        //                }
        //            }
        //        }
        //        totalWays += solution(popularity, index - 1);
        //    }
        //    return totalWays;
        //}

        public static int Solution(string s)
        {
            if (s.Length % 2 != 0)
            {
                return 0;
            }

            int result = 0;
            int totalOpen1 = 0, totalOpen2 = 0, 
                totalClose1 = 0, totalClose2 = 0, 
                totalQuestionMarks = 0;

            for (int i = 0; i < s.Length; i++)
            {
                IdentiyAndSumBracket(s[i], ref totalOpen1, ref totalOpen2, ref totalClose1, ref totalClose2, ref totalQuestionMarks);
            }

            int totalSubstringOpen1 = 0, totalSubstringOpen2 = 0, 
                totalSubstringClose1 = 0, totalSubstringClose2 = 0, 
                totalSubstringQuestionMarks = 0;

            bool isSubString1Balanced = false;

            for (int i = 1; i < s.Length - 2; i += 2)
            {
                IdentiyAndSumBracket(s[i - 1], ref totalSubstringOpen1, ref totalSubstringOpen2, ref totalSubstringClose1, ref totalSubstringClose2, ref totalSubstringQuestionMarks);
                IdentiyAndSumBracket(s[i], ref totalSubstringOpen1, ref totalSubstringOpen2, ref totalSubstringClose1, ref totalSubstringClose2, ref totalSubstringQuestionMarks);

                isSubString1Balanced = IsRearrangedBalanceString(totalSubstringOpen1, totalSubstringOpen2, totalSubstringClose1, totalSubstringClose2, totalSubstringQuestionMarks);

                if (isSubString1Balanced)
                {
                    result += isSubString1Balanced && IsRearrangedBalanceString(totalOpen1 - totalSubstringOpen1,
                                                                                totalOpen2 - totalSubstringOpen2,
                                                                                totalClose1 - totalSubstringClose1,
                                                                                totalClose2 - totalSubstringClose2,
                                                                                totalQuestionMarks - totalSubstringQuestionMarks) ? 1 : 0;
                }
            }

            return result;
        }

        public static void IdentiyAndSumBracket(char c, ref int open1, ref int open2, ref int close1, ref int close2, ref int questionMarks)
        {
            if (c == '[')
            {
                open1++;
            }
            else if (c == ']')
            {
                close1++;
            }
            else if (c == '(')
            {
                open2++;
            }
            else if (c == ')')
            {
                close2++;
            }
            else
            {
                questionMarks++;
            }
        }

        public static bool IsRearrangedBalanceString(int open1, int open2, int close1, int close2, int questionMarks)
        {
            int remainingUnmatchedBrackets = Math.Abs(open1 - close1) + Math.Abs(open2 - close2);
            if (remainingUnmatchedBrackets == 0)
            {
                return questionMarks % 2 == 0;
            }

            int remainingQuestionMarks = (questionMarks - remainingUnmatchedBrackets);
            return remainingQuestionMarks >= 0 && remainingQuestionMarks % 2 == 0;
        }

        //public static int fillMissingBrackets(string s)
        //{
        //    int result = 0;
        //    result = solution(s, 2);
        //    return result;
        //}

        //static int solution(string s, int numberOfItemsOfFirstString)
        //{
        //    int result = 0;
        //    bool isFirstStringBalance = false, isSecondStringBalance = false;
        //    if (s.Length > numberOfItemsOfFirstString) {
        //        isFirstStringBalance = isBalance(s, 0, numberOfItemsOfFirstString);

        //        if (isFirstStringBalance) { 
        //            isSecondStringBalance = isBalance(s, numberOfItemsOfFirstString, s.Length);
        //        }

        //        if (isFirstStringBalance == true && isSecondStringBalance == true) {
        //            result++;
        //        }

        //        result += solution(s, numberOfItemsOfFirstString + 2);
        //    }
        //    return result;
        //}

        //static bool isBalance(string s, int startIndex, int endIndex) {
        //    bool result = false;
        //    int numberOfOpenBrakets = 0, numberOfCloseBrakets = 0, numberOfOpenSquare = 0, numberOfCloseSquare = 0,
        //        numberOfQuestions = 0;
        //    for (int i = startIndex; i < endIndex; i++)
        //    {
        //        if (s[i] == '(')
        //        {
        //            numberOfOpenBrakets++;
        //        }
        //        else if (s[i] == ')')
        //        {
        //            numberOfCloseBrakets++;
        //        }
        //        else if (s[i] == '[')
        //        {
        //            numberOfOpenSquare++;
        //        }
        //        else if (s[i] == ']')
        //        {
        //            numberOfCloseSquare++;
        //        }
        //        else {
        //            numberOfQuestions++;
        //        }
        //    }

        //    int numberOfItemsToAdd = Math.Abs(numberOfOpenBrakets - numberOfCloseBrakets) + Math.Abs(numberOfOpenSquare - numberOfCloseSquare);

        //    int remainingQuestions = numberOfQuestions - numberOfItemsToAdd;

        //    if (remainingQuestions % 2 == 0 && remainingQuestions >= 0) {
        //        result = true;
        //    }

        //    return result;
        //}

        public static int ways(int total, int k)
        {
            Dictionary<string, int> memoization = new Dictionary<string, int>();

            return subProblem(total, k, 1, memoization);
        }

        public static int subProblem(int money, int k, int startPoint, Dictionary<string, int> memoization)
        {
            int ways = 0;

            if (money == 0)
            {
                return 1;
            }
            else if (money < 0)
            {
                return 0;
            }

            for (int i = startPoint; i <= k; i++)
            {
                ways += subProblem(money - i, k, i, memoization);
            }

            return ways;
        }

        public static string ReverseString(string s)
        { 
            char[] result = new char[s.Length];

            Recur(s, result, 0);
            return string.Concat(result);
        }

        public static void Recur(string s, char[] result, int point)
        {
            if (point > s.Length / 2)
            {
                return;
            }

            result[point] = s[(s.Length - 1) - point];
            result[(s.Length - 1) - point] = s[point];

            Recur(s, result, point +1);
        }

        static int sum(int[] A, int i, int prevTotal, Dictionary<string, int> memo = null)
        {
            if (i == A.Length)
                return prevTotal;

            string key = $"{A[i]}-{Math.Abs(prevTotal)}";
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }
            var result = Math.Min(Math.Abs(sum(A, i + 1, A[i] + prevTotal, memo)), Math.Abs(sum(A, i + 1, A[i] - prevTotal, memo)));

            if (!memo.ContainsKey(key))
            {
                memo.Add(key, result);
            }
            

            return result;
        }

        //public static int solution(int[] A)
        //{
        //    Dictionary<string, int> memo = new Dictionary<string, int>();
        //    return sum(A, 0, 0, memo);
        //}

        //public static int solution(int[] A)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //    int[] store = new int[A.Length];
        //    store[0] = A[0];
        //    for (int i = 1; i < A.Length; i++)
        //    {
        //        store[i] = store[i - 1];
        //        for (int minus = 2; minus <= 6; minus++)
        //        {
        //            if (i >= minus)
        //            {
        //                store[i] = System.Math.Max(store[i], store[i - minus]);
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        store[i] += A[i];
        //    }
        //    return store[A.Length - 1];
        //}

        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int totalOpens = 0, totalClose = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    totalOpens++;
                }
                else
                {
                    totalClose++;
                }
            }

            if (S.Length == 2)
            {
                return System.Math.Max(totalOpens, totalClose);
            }

            int openLeft = 0, closeLeft = 0, openRight = totalOpens, closeRight = totalClose, idx =0;
            for (idx  = 0; idx < S.Length; idx++)
            {
                if (S[idx] == '(')
                {
                    openLeft++;

                    openRight--;

                }
                else
                {
                    closeLeft++;

                    closeRight--;
                }

                if (openLeft == closeRight)
                {
                    break;
                }
            }

            return idx + 1;
        }
        static void Main(string[] args)
        {
            //# List vs Array
            //int[] a = new int[10];
            //List<int> a2 = new List<int>(10);
            //a2.Add(20);
            //a2.Add(21);

            //var i = a[9];
            //var i2 = a2[3];

            //Dictionary vs List
            //Dictionary features: Unique Key
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<int> list = new List<int>();
        }

       

        public static int solution4(int X, int Y, int[] A)
        {
            int N = A.Length;
            int result = -1;
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                    nX += 1;
                else if (A[i] == Y)
                    nY += 1;
                if (nX == nY && nX != 0 && nY != 0)
                    result = i;
            }
            return result;
        }

        public static int solution3(int X, int Y, int[] A)
        {
            int N = A.Length;
            int result = -1;
            int nX = -1;
            int nY = -1;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                    nX = i;
                else if (A[i] == Y)
                    nY = i;
                if (nX != -1 && nY != -1)
                    result = i;
            }

            return result;
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
