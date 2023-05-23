using System;
using System.Xml;

namespace InteroperabilityTest
{
    class CSharpLibrary
    {
        public enum ErrorCode : sbyte
        {
            eNO_ERROR = 0,
            eERROR = -1,
        }
        
        public static int GetData(out string strText, out int iNumber, out double dNumber)
        {
            strText = "Hello World";
            iNumber = 1337;
            dNumber = 23.123456;
            Console.WriteLine("C# Return to C:\nstrText " + strText + "\niNumber " + iNumber + "\ndNumber " + dNumber);
            return (int)CSharpLibrary.ErrorCode.eNO_ERROR;
        }

        public static int SetData(string strText, int iNumber, double dNumber)
        {
            Console.WriteLine("C# Check Input from C:\nstrText " + strText + "\niNumber " + iNumber + "\ndNumber " + dNumber);
            if (strText == "Hello World" && iNumber == 1337 && dNumber == 23.123456)
            {
                return (int)CSharpLibrary.ErrorCode.eNO_ERROR;
            }
            else
            {
                return (int)CSharpLibrary.ErrorCode.eERROR;
            }
        }

        public static int GetXMLString(string strPathToXMLFile, out string stringXMLReturn)
        {
            stringXMLReturn = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(strPathToXMLFile);

                XmlElement xmlRoot = doc.DocumentElement;

                XmlNodeList elemList = xmlRoot.GetElementsByTagName("item");
                stringXMLReturn = elemList[0].Attributes[0].Value;
                if (stringXMLReturn != "world")
                {
                    return (int)CSharpLibrary.ErrorCode.eERROR;
                }
                Console.WriteLine("C# Return from XML file to C:\n " + stringXMLReturn);
            }
            catch (Exception ExceptionObjet)
            {
                Console.WriteLine(ExceptionObjet.Message);
                Console.WriteLine(ExceptionObjet.StackTrace);

                return (int)CSharpLibrary.ErrorCode.eERROR;
            }

            return (int)CSharpLibrary.ErrorCode.eNO_ERROR;
        }
    }
}
