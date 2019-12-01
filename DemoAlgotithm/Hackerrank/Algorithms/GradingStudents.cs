using System;
using System.Collections.Generic;
using System.Text;

namespace Hackerrank.Algorithms
{
    public class GradingStudents
    {
        /// Time Complexity is O(n)
        /// Space Complexity is O(n)
        public static List<int> Solution(List<int> grades)
        {
            int nextMultipleOfFive = 0, tempResult = 0;
            List<int> results = new List<int>(grades.Count);

            for (int i = 0; i < grades.Count; i++)
            {
                tempResult = grades[i];
                if (tempResult >= 38)
                {
                    nextMultipleOfFive = ((tempResult / 5) + 1) * 5;
                    if (nextMultipleOfFive - tempResult < 3)
                    {
                        tempResult = nextMultipleOfFive;
                    }
                }

                results.Add(tempResult);
            }

            return results;
        }
    }
}
