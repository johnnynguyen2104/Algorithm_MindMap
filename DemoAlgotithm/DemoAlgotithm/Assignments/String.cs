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
