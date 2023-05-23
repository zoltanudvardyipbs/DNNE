using System.Runtime.InteropServices;

namespace InteroperabilityTest
{
    class CSharpLibraryExport
    {
        [UnmanagedCallersOnlyAttribute(EntryPoint = "GetData")] //functions name for C interface
        public static int GetData([DNNE.C99Type("const char**")] System.IntPtr StringText, [DNNE.C99Type("int*")] System.IntPtr intNumber, [DNNE.C99Type("double*")] System.IntPtr doubleNumber)
        {
            var returnValue = CSharpLibrary.GetData(out string strText, out int iNumber, out double dNumber);
            Marshal.WriteIntPtr(StringText, Marshal.StringToHGlobalAnsi(strText));
            Marshal.WriteInt32(intNumber, iNumber);
            double[] val = new double[1];
            val[0] = dNumber;
            Marshal.Copy(val, 0, doubleNumber, 1);
            return returnValue;
        }

        [UnmanagedCallersOnlyAttribute(EntryPoint = "SetData")] //functions name for C interface
        public static int SetData([DNNE.C99Type("const char*")] System.IntPtr StringText, int intNumber, double doubleNumber)
        {
            var returnValue = CSharpLibrary.SetData(Marshal.PtrToStringAnsi(StringText), intNumber, doubleNumber);
            return returnValue;
        }

        [UnmanagedCallersOnlyAttribute(EntryPoint = "GetXMLString")] //functions name for C interface
        public static int GetXMLString([DNNE.C99Type("const char*"),] System.IntPtr strPathToXMLFile, [DNNE.C99Type("const char**")] System.IntPtr ReturnStringXMLReturn)
        {
            var returnValue = CSharpLibrary.GetXMLString(Marshal.PtrToStringAnsi(strPathToXMLFile), out string StringXMLReturn);
            Marshal.WriteIntPtr(ReturnStringXMLReturn, Marshal.StringToHGlobalAnsi(StringXMLReturn));
            return returnValue;
        }

    }
}
