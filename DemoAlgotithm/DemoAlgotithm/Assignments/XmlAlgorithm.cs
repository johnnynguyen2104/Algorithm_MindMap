using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoAlgotithm.Assignments
{
    public class XmlAlgorithm
    {
        public static XmlDocument ParseStringToXml(string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
            {
                return null;
            }

            XmlDocument xmlDocument;
            xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xmlString);
            }
            catch (XmlException ex)
            {
                throw ex;
            }

            return xmlDocument;
        }

        /// <summary>
        /// Find Deepest level of Xml
        /// </summary>
        /// <param name="document"></param>
        /// <param name="node"></param>
        /// <param name="currentLv">By Default will be -1 because we start from the Document</param>
        /// <returns></returns>
        public static int DeepestXmlLevel(XmlDocument document, XmlNode node = null, int currentLv = -1)
        {
            XmlNodeList list = document == null ? node.ChildNodes : document.ChildNodes;
            currentLv++;
            int maxlv = 0;
            int level = 0;
            foreach (XmlNode cNode in list)
            {
                level = DeepestXmlLevel(null, cNode, currentLv);
                if (maxlv < level)
                {
                    maxlv = level;
                }
            }

            return (maxlv > currentLv ? maxlv : currentLv);
        }
    }
}
