using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
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
            Dictionary<char, int> result= new Dictionary<char, int>();
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
    }
}
