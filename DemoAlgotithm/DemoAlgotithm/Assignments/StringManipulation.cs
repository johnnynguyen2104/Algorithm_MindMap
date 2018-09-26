﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        /*
         Given two cells on the standard chess board, determine whether they have the same color or not.
             */
        public static bool chessBoardCellColor(string cell1, string cell2)
        {
            int alp = cell1.Substring(0, 1)[0], alp2 = cell2.Substring(0, 1)[0];
            int digit = int.Parse(cell1.Substring(1)), digit2 = int.Parse(cell2.Substring(1));

            bool color1 = (alp % 2 != 0 && digit % 2 != 0) || (alp % 2 == 0 && digit % 2 == 0),
                color2 = (alp2 % 2 != 0 && digit2 % 2 != 0) || (alp2 % 2 == 0 && digit2 % 2 == 0);

            return (color1 && color2) || (!color1 && !color2);
        }

        /*
         Given a string, replace each its character by the next one in the English alphabet (z would be replaced by a).
             */
        string AlphabeticShift(string inputString)
        {
            StringBuilder result = new StringBuilder(inputString.Length);
            int tempASCII = -1;
            for (int i = 0; i < inputString.Length; i++)
            {
                tempASCII = inputString[i] + 1;
                if (tempASCII > 122 || (tempASCII > 90 && tempASCII <97))
                {
                    tempASCII -= 26;
                }
                result.Append((char)tempASCII);
            }

            return result.ToString();
        }


        /*
         Correct variable names consist only of English letters, digits and underscores and they can't start with a digit.
             */
        public static bool VariableName(string name)
        {
            int asciiDec = name[0];
            if ((asciiDec >= 48 && asciiDec <= 57))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                asciiDec = (int)name[i];
                if ((asciiDec < 65 || asciiDec > 90)
                    && (asciiDec < 97 || asciiDec > 122)
                    && (asciiDec < 48 || asciiDec >57)
                    && asciiDec != 95)
                {
                    return false;
                }
            }

            return true;
        }


        #region
        /*
         You have a string s that consists of English letters, punctuation marks, whitespace characters, and brackets. 
         It is guaranteed that the parentheses in s form a regular bracket sequence.

        Your task is to reverse the strings contained in each pair of matching parentheses, starting from the innermost pair. The results string should not contain any parentheses.

        Example

        For string s = "a(bc)de", the output should be
        reverseParentheses(s) = "acbde".
             */
        #endregion
        public static string ReverseParentheses(string s)
        {
            StringBuilder builder = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    builder.Append(ReverseSubStringInParentheses(s, i + 1, ref i));
                }
                else
                {
                    builder.Append(s[i]);
                }

            }

            return builder.ToString();
        }

        private static string ReverseSubStringInParentheses(string s, int startIndex, ref int outputIndex)
        {
            string children = "";

            if (s[startIndex] == '(')
            {
                int i = 0;
                for (i = startIndex + 1; s[i] != ')'; i++)
                {
                    if (s[i] == '(')
                    {
                        children += ReverseSubStringInParentheses(s, i + 1, ref i);
                    }
                    else
                    {
                        children += s[i];
                    }
                }
                startIndex = i;

            }
            else if (s[startIndex] == ')')
            {
                outputIndex = startIndex;
                return null;
            }

            var currentChar = s[startIndex] == ')' || s[startIndex] == '(' ? "" : s[startIndex].ToString();

            return ReverseSubStringInParentheses(s, startIndex + 1, ref outputIndex) + currentChar + children;
        }

        /*
         This function for order by(DESC) a string (not using loop) 
             */
        private static string OrderByDESCSubStringInParentheses(string s, int startIndex, ref int outputIndex)
        {
            //string children = "";

            //if (s[startIndex] == '(')
            //{
            //    children = ReverseSubStringInParentheses(s, startIndex + 1, ref outputIndex);
            //    startIndex = outputIndex;
            //}

            if (s[startIndex] == ')')
            {
                outputIndex = startIndex;
                return null;
            }

            var comparer = OrderByDESCSubStringInParentheses(s, startIndex + 1, ref outputIndex);

            return (s[startIndex].CompareTo(comparer == null ? ' ' : comparer[0]) < 0 ? comparer + s[startIndex] : s[startIndex] + comparer);
        }



        //Given two strings, find the number of common characters between them.
        public static int CommonCharacterCount(string s1, string s2)
        {
            Dictionary<char, int> list1 = new Dictionary<char, int>()
                , list2 = new Dictionary<char, int>();
            int resultMatch = 0;

            list1 = StringToDictionary(s1);
            list2 = StringToDictionary(s2);

            foreach (KeyValuePair<char, int> l in list1)
            {
                if (list2.ContainsKey(l.Key))
                {
                    resultMatch += list1[l.Key] > list2[l.Key] ? list2[l.Key] : list1[l.Key];
                }
            }

            return resultMatch;
        }

        private static Dictionary<char, int> StringToDictionary(string s1)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (!result.ContainsKey(c))
                {
                    result.Add(c, 1);
                }
                else
                {
                    result[c]++;
                }
            }

            return result;
        }

        public static int DeepestLevelOfXml(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return 0;
            }

            XmlDocument xmlDocument;
            xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(source);
            }
            catch (XmlException ex)
            {
                throw ex;
            }


            return 0;
        }

        public static bool CheckPalindrome(string inputString)
        {
            int length = inputString.Length;

            if (length == 1)
            {
                return true;
            }

            for (int i = 0; i < length / 2; i++)
            {

                if (inputString[i] != inputString[(length - 1) - i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string FindSubStringInString(string s, string pattern = "hackerrank")
        {
            StringBuilder result = new StringBuilder();
            int indexResult = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == pattern[indexResult])
                {
                    indexResult++;
                }
                else
                {
                    indexResult = 0;
                }

                if (indexResult == pattern.Length)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
