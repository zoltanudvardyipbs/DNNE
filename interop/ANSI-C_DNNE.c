#include <stdlib.h>
#include <stdio.h>
#include "InteroperabilityTestNE.h"

int main(void)
{
    int iError = 0;

    char *strTextOut = NULL;
    //char sResultText[OPTO_GLOBAL_MAX_PROCESSING_STRING_DATA_SIZE] = {""};
    int iNumberOut = 0;
    double dNumberOut = 0;

    char strTextIn[] = "Hello World";
    int iNumberIn = 1337;
    double dNumberIn = 23.123456;

    char strPathToXMLFile1[] = "File.xml";
    char *strXMLReturn = NULL;

    iError = GetData(&strTextOut, &iNumberOut, &dNumberOut);
    iError = FreeAnsiString(strTextOut);

    iError = SetData(strTextIn, iNumberIn, dNumberIn);
    iError = GetXMLString(strPathToXMLFile1, &strXMLReturn);

    printf("content before free: %s\n", strXMLReturn);
    iError = FreeAnsiString(strXMLReturn);
    
    printf("content after free: %s\n", strXMLReturn);

    return 0;
}

