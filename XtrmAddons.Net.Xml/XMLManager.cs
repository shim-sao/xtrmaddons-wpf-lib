using System;
using System.IO;
using System.Xml;

namespace WPFXA.Net.Xml
{
    public class XMLManager
    {
        /// <summary>
        /// Method to load XmlDocument.
        /// </summary>
        public static XmlDocument LoadXml(string fullFilePath)
        {
            // Create file stream.
            if (new FileInfo(fullFilePath).Length != 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fullFilePath);

                return xmlDoc;
            }

            return null;
        }

        /// <summary>
        /// Method to open stream to a file.
        /// </summary>
        public static FileStream Open(string fullFilePath)
        {
            return System.IO.File.Open(fullFilePath, FileMode.Open);
        }

        /// <summary>
        /// Method to convert XmlDocument convert XmlDocument to XML node list.
        /// </summary>
        public static XmlNodeList DocList(XmlDocument document)
        {
            if (document != null)
            {
                XmlNode node = document.DocumentElement;
                try
                {
                    XmlNodeList nodeList = node.ChildNodes;
                    return nodeList;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// Method to load and convert XmlDocument to XML node list.
        /// </summary>
        public static XmlNodeList LoadToDocList(string fullFilePath)
        {
            return DocList(LoadXml(fullFilePath));
        }
    }
}
