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
    char *StringXMLReturn = NULL;

    iError = GetData(&strTextOut, &iNumberOut, &dNumberOut);
    iError = SetData(strTextIn, iNumberIn, dNumberIn);
    iError = GetXMLString(strPathToXMLFile1, &StringXMLReturn);

    printf("content before free: %s\n", StringXMLReturn);
    iError = FreeAnsiString(StringXMLReturn);

    
    printf("content after free: %s\n", StringXMLReturn);

    return 0;
}

