using System;

namespace InteroperabilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string strTextOut;
            int iNumberOut;
            double dNumberOut;
            int iError = 0;
            iError = CSharpLibrary.GetData(out strTextOut, out iNumberOut, out dNumberOut);
            if (iError != 0)
            {
                Console.WriteLine("FAIL!!!");
                Console.ReadKey();
            }

            string strTextIn = "Hello World";
            int iNumberIn = 1337;
            double dNumberIn = 23.123456;

            iError = CSharpLibrary.SetData(strTextIn, iNumberIn, dNumberIn);
            if (iError != 0)
            {
                Console.WriteLine("FAIL!!!");
                Console.ReadKey();
            }

            string strPathToXMLFile1 = "file.xml";
            string StringXMLReturn;
            iError = CSharpLibrary.GetXMLString(strPathToXMLFile1, out StringXMLReturn);
            if (iError != 0)
            {
                Console.WriteLine("FAIL!!!");
                Console.ReadKey();
            }
            Console.WriteLine("PASS :) !!!");
        }
    }
}
